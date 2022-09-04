using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using SimulFactory.System.Common;
using Newtonsoft.Json;
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
            SendPacket(0, new Dictionary<byte, object>());
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
        public void SendPacket(byte eventCode, Dictionary<byte,object> param)
        {
            eventCode = (byte)Define.EVENT_CODE.PlayerNameC;

            reqData.eventCode = 113;
            reqData.data.Add(0, "UserName");
            Debug.Log(reqData.data[0]);
            m_Socket.Send(JsonConvert.SerializeObject(reqData));
            Debug.Log(JsonConvert.SerializeObject(reqData));
        }
        private void DataProcess(ReceivedPacketData recvData)
        {
            Dictionary<byte, object> param = recvData.data;
            switch(recvData.eventCode)
            {
                case 0:
                    break;
                case 1:
                    break;
                default:
                    break;
            }
        }

        #region ������ �޾Ƽ� ����Ʈ�� �־� ó���� �� ��� �ϴ� �ڵ� - ���� ������
        /*
        /// <summary>
        /// �޾ƿ� �����͸� ó����.
        /// </summary>
        private void DataProcess()
        {
            for (int i = 0; i < data.Count; i++)
            {
                recvData = JsonUtility.FromJson<RecvData>(data[i]);
                switch(recvData.type)
                {
                    case "PlayerName":
                        ResPlayerName.PlayerNameResponse(recvData.data);
                        break;
                    case "MakeRoom":
                        ResMakeRoom.MakeRoomResponse(recvData.data,recvData.subData);
                        break;
                    case "RoomList":
                        ResRoomList.RoomListResponse(recvData.data);
                        break;
                    default:
                        break;
                }
            }
            data.Clear();
        }

        
        /// <summary>
        /// 0.1�ʸ��� �����Ͱ� �ִ��� Ȯ�� �� ó���ϰ� ��.
        /// </summary>
        /// <returns></returns>
        IEnumerator DataChecker()
        {
            waitForSeconds = new WaitForSeconds(0.1f);
            while (true)
            {
                if(recvDataList.Count > 0)
                {
                    DataProcess();
                }
                yield return waitForSeconds;
            }
        }
        */
        #endregion
    }
}