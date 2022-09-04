using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using SimulFactory.System.Common;
using Newtonsoft.Json;
using SimulFactory.Game.Event;
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
        private List<ReceivedPacketData> recvDataList;
        private WebSocketSharp.WebSocket m_Socket = null;
        private RequestPacketData reqData;
        private ReceivedPacketData recvData;
        private void Awake()
        {
            recvDataList = new List<ReceivedPacketData>();
            recvData = new ReceivedPacketData();
            recvData.data = new Dictionary<byte, object>();
            reqData = new RequestPacketData();
            reqData.data = new Dictionary<byte, object>();
        }
        private void Start()
        {
            m_Socket = new WebSocketSharp.WebSocket("ws://MYWATTBATBET.asuscomm.com:3000"); // ���� ip�ּ�
            //m_Socket = new WebSocketSharp.WebSocket("ws://127.0.0.1:80"); // ���� ip�ּ�
            m_Socket.OnMessage += Recv;
            m_Socket.Connect();
            StartCoroutine(CheckServer());
        }
        IEnumerator CheckServer()
        {
            while(m_Socket.ReadyState != WebSocketState.Open)
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
            recvData = JsonConvert.DeserializeObject<ReceivedPacketData>(e.Data);
            DataProcess(recvData);
        }
        public void SendPacket(byte eventCode)
        {
            reqData.eventCode = eventCode;
            reqData.data = new Dictionary<byte, object>();
            m_Socket.Send(JsonConvert.SerializeObject(reqData));
            Debug.Log(JsonConvert.SerializeObject(reqData));
        }
        public void SendPacket(byte eventCode, Dictionary<byte,object> param)
        {
            reqData.Clear();
            reqData.eventCode = eventCode;
            reqData.data = param;
            reqData.data.Add(120, 0);   // �� ó���� ������
            m_Socket.Send(JsonConvert.SerializeObject(reqData));
            Debug.Log(JsonConvert.SerializeObject(reqData));
        }
        public WebSocketState GetWebSocketState()
        {
            if(m_Socket == null)
            {
                return WebSocketState.Closed;
            }
            return m_Socket.ReadyState;
        }
        private void DataProcess(ReceivedPacketData recvData)
        {
            Dictionary<byte, object> param = recvData.data;
            switch(recvData.eventCode)
            {
                case (byte)Define.EVENT_CODE.LoginS:
                    S_Login.LoginS(param);
                    break;
                case (byte)Define.EVENT_CODE.MatchingSuccessS:
                    Debug.Log("Match Success");
                    break;
                default:
                    break;
            }
        }

    }
}