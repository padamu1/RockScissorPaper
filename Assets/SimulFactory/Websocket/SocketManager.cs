using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using Newtonsoft.Json;
using SimulFactory.System.Common;
using SimulFactory.Game.Event;
using SimulFactory.Manager;
using System;
/// <summary>
/// ������ ���� �� ����ϴ� Ŭ����
/// </summary>
[System.Serializable]
public class RequestPacketData
{
    public byte eventCode;
    public Dictionary<byte, object> data;
    public void Clear()
    {
        eventCode = 0;
        data.Clear();
    }
}

/// <summary>
/// ������ ���� �� ����ϴ� Ŭ����
/// </summary>
[System.Serializable]
public class ReceivedPacketData
{
    public byte eventCode;
    public Dictionary<byte, object> data;
}

namespace SimulFactory.WebSocket
{
    /// <summary>
    /// ������ ó�� �ֿ� Ŭ����.
    /// </summary>
    public class SocketManager : MonoSingleton<SocketManager>
    {
        private WebSocketSharp.WebSocket m_Socket = null;
        private RequestPacketData m_reqData;
        private ReceivedPacketData m_recvData;
        private Queue<ReceivedPacketData> m_receivedPacketDatas = new Queue<ReceivedPacketData>();
        private bool m_disconnect = false;
        private Dictionary<int,Action<Dictionary<byte,object>>> _callbackDic;
        private void Awake()
        {
            m_recvData = new ReceivedPacketData();
            m_recvData.data = new Dictionary<byte, object>();
            m_reqData = new RequestPacketData();
            m_reqData.data = new Dictionary<byte, object>();
            _callbackDic = new Dictionary<int,Action<Dictionary<byte,object>>>();
        }
        public void Init()
        {
            m_Socket = new WebSocketSharp.WebSocket("ws://MYWATTBATBET.asuscomm.com:3000"); // ���� ip�ּ�
            //m_Socket = new WebSocketSharp.WebSocket("ws://127.0.0.1:80"); // ���� ip�ּ�
            m_Socket.OnMessage += Recv;
            m_Socket.OnClose += OnClose;
            Connect();
        }

        #region �⺻ ����
        /// <summary>
        /// ������ ������ �õ��ϴ� �Լ�
        /// </summary>
        public void Connect()
        {
            m_Socket.Connect();
            StartCoroutine(CheckServer());
        }
        IEnumerator CheckServer()
        {
            while (m_Socket.ReadyState != WebSocketState.Open)
            {
                yield return new WaitForSeconds(0.01f);
            }
            Debug.Log("Websocket Connected");
        }

        /// <summary>
        /// ���ο� �����͸� �޾ƿ��� �޼���.
        /// </summary
        private void Recv(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Data);
            m_recvData = JsonConvert.DeserializeObject<ReceivedPacketData>(e.Data);
            m_receivedPacketDatas.Enqueue(new ReceivedPacketData() { eventCode = m_recvData.eventCode, data = m_recvData.data});
        }
        /// <summary>
        /// ������ �޽��� ���� �� ���
        /// </summary>
        /// <param name="eventCode"></param>
        public void SendPacket(byte eventCode)
        {
            m_reqData.Clear();
            m_reqData.eventCode = eventCode;
            m_Socket.Send(JsonConvert.SerializeObject(m_reqData));
        }
        /// <summary>
        /// ������ �޽��� ���� �� ���
        /// </summary>
        /// <param name="eventCode"></param>
        /// <param name="param"></param>
        public void SendPacket(byte eventCode, Dictionary<byte, object> param)
        {
            m_reqData.Clear();
            m_reqData.eventCode = eventCode;
            m_reqData.data = param;
            m_Socket.Send(JsonConvert.SerializeObject(m_reqData));
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
        public bool CheckCallBack(ReceivedPacketData recvData)
        {
            if(_callbackDic.ContainsKey(recvData.eventCode))
            {
                _callbackDic[recvData.eventCode].Invoke(recvData.data);
                return true;
            }
            return false;
        }

        private void Update()
        {
            if(!m_disconnect)
            {
                if (m_receivedPacketDatas.Count > 0)
                {
                    WorldManager.GetInstance().DataProcess(m_receivedPacketDatas.Dequeue());
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