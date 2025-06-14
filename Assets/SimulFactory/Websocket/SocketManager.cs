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
using System.Threading.Tasks;

namespace SimulFactory.WebSocket
{
    /// <summary>
    /// ������ ó�� �ֿ� Ŭ����.
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
           // m_Socket = new WebSocketSharp.WebSocket("ws://MYWATTBATBET.asuscomm.com:3000"); // ���� ip�ּ�
            m_Socket = new WebSocketSharp.WebSocket("ws://rspserver.koreacentral.cloudapp.azure.com:3000");
            //m_Socket = new WebSocketSharp.WebSocket("ws://127.0.0.1:80"); // ���� ip�ּ�
            m_Socket.OnMessage += Recv;
            m_Socket.OnClose += OnClose;
            Connect();
            StartCoroutine(CheckServerConnect(action));
        }

        #region �⺻ ����
        /// <summary>
        /// ������ ������ �õ��ϴ� �Լ�
        /// </summary>
        public void Connect()
        {
            Task task = new Task(CheckServer);
            task.Start();
            //StartCoroutine(CheckServer(action));
        }

        private void CheckServer()
        {
            m_Socket.ConnectAsync();
        }
        IEnumerator CheckServerConnect(Action action)
        {
            int waitCount = 0;
            while (m_Socket.ReadyState != WebSocketState.Open)
            {
                if (waitCount++ > 500f)
                {
                    yield break;
                }
                yield return null;
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
        /// ���ο� �����͸� �޾ƿ��� �޼���.
        /// </summary
        private void Recv(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Data);
            PacketData receivedData = (PacketData)Serializer.Deserialize(e.RawData);
            if(receivedData != null)
            {
                receivedPacketQueue.Enqueue(receivedData);
            }
        }
        /// <summary>
        /// ������ �޽��� ���� �� ���
        /// </summary>
        /// <param name="eventCode"></param>
        public void SendPacket(byte eventCode)
        {
            sendPacketData.Data.Clear();
            sendPacketData.EvCode = eventCode;
            m_Socket.Send(Serializer.Serialize(sendPacketData));
        }
        /// <summary>
        /// ������ �޽��� ���� �� ���
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
        /// ���� ������ �� ȣ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, CloseEventArgs e)
        {
            m_disconnect = true;
        }
        /// <summary>
        /// �������� ������ ���� �Լ�
        /// </summary>
        public void Disconnect()
        {
            UiManager.GetInstance().gameObject.SetActive(false);
            m_Socket.Close();
            Debug.Log("���� ���� ����");

            Managers.GetInstance().GetMasterContext().Reset();

            // �ΰ������ �̵�
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
                Debug.Log("���� ���� ����");
                m_disconnect = false;
                Disconnect();
            }
        }

    }
}