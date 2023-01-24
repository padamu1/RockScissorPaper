using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using Newtonsoft.Json;
using SimulFactory.System.Common;
using SimulFactory.Game.Event;
using SimulFactory.Manager;
using System;
using SimulFactory.PacketSerializer.Model;
using PacketSerializer;

namespace SimulFactory.WebSocket
{
    /// <summary>
    /// 데이터 처리 주요 클래스.
    /// </summary>
    public class SocketManager : MonoSingleton<SocketManager>
    {
        private WebSocketSharp.WebSocket m_Socket = null;
        private PacketData sendPacketData;
        private Queue<PacketData> receivedPacketQueue = new Queue<PacketData>();
        private bool m_disconnect = false;
        private Dictionary<byte, Action<Dictionary<byte, object>>> _callbackDic;
        private void Awake()
        {
            sendPacketData = new PacketData(0,new Dictionary<byte, object>());
            _callbackDic = new Dictionary<byte, Action<Dictionary<byte, object>>>();
        }
        public void Init(Action action)
        {
            //m_Socket = new WebSocketSharp.WebSocket("ws://MYWATTBATBET.asuscomm.com:3000"); // 서버 ip주소
            m_Socket = new WebSocketSharp.WebSocket("ws://timinetprinter.iptime.org:3000");
            //m_Socket = new WebSocketSharp.WebSocket("ws://127.0.0.1:80"); // 서버 ip주소
            m_Socket.OnMessage += Recv;
            m_Socket.OnClose += OnClose;
            Connect(action);
        }

        #region 기본 로직
        /// <summary>
        /// 서버와 연결을 시도하는 함수
        /// </summary>
        public void Connect(Action action)
        {
            StartCoroutine(CheckServer(action));
        }
        IEnumerator CheckServer(Action action)
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
            int waitCount = 0;
            m_Socket.ConnectAsync();
            while (m_Socket.ReadyState != WebSocketState.Open)
            {
                if (waitCount++ > 5f)
                {
                    yield break;
                }
                yield return waitForSeconds;
            }
            if (m_Socket.ReadyState != WebSocketState.Open)
            {
                Disconnect();
            }
            else
            {
                action.Invoke();
                Debug.Log("Websocket Connected");
            }
        }

        /// <summary>
        /// 새로운 데이터를 받아오는 메서드.
        /// </summary
        private void Recv(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Data);
            receivedPacketQueue.Enqueue((PacketData)Serializer.Deserialize(e.RawData));
        }
        /// <summary>
        /// 서버에 메시지 보낼 때 사용
        /// </summary>
        /// <param name="eventCode"></param>
        public void SendPacket(byte eventCode)
        {
            sendPacketData.Data.Clear();
            sendPacketData.EvCode = eventCode;
            m_Socket.Send(Serializer.Serialize(sendPacketData));
        }
        /// <summary>
        /// 서버에 메시지 보낼 때 사용
        /// </summary>
        /// <param name="eventCode"></param>
        /// <param name="param"></param>
        public void SendPacket(byte eventCode, Dictionary<byte, object> param)
        {
            sendPacketData.Data = param;
            sendPacketData.EvCode = eventCode;
            m_Socket.Send(Serializer.Serialize(sendPacketData));
        }
        /// <summary>
        /// 연결 끊겼을 때 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, CloseEventArgs e)
        {
            m_disconnect = true;
        }
        /// <summary>
        /// 서버와의 연결을 끊는 함수
        /// </summary>
        public void Disconnect()
        {
            UiManager.GetInstance().gameObject.SetActive(false);
            m_Socket.Close();
            Debug.Log("서버 연결 끊음");

            Managers.GetInstance().GetMasterContext().Reset();

            // 로고씬으로 이동
            Managers.GetInstance().LoadScene("Logo");
        }
        public WebSocketState GetWebSocketState()
        {
            if (m_Socket == null)
            {
                return WebSocketState.Closed;
            }
            return m_Socket.ReadyState;
        }
        #endregion
        public bool CheckCallBack(PacketData packet)
        {
            if (_callbackDic.ContainsKey(packet.EvCode))
            {
                _callbackDic[packet.EvCode].Invoke(packet.Data);
                return true;
            }
            return false;
        }

        private void Update()
        {
            if (!m_disconnect)
            {
                if (receivedPacketQueue.Count > 0)
                {
                    WorldManager.GetInstance().DataProcess(receivedPacketQueue.Dequeue());
                }
            }
            else
            {
                Debug.Log("서버 연결 끊김");
                m_disconnect = false;
                Disconnect();
            }
        }

    }
}