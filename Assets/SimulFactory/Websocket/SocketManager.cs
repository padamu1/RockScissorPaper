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
/// 데이터 보낼 때 사용하는 클래스
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
/// 데이터 받을 때 사용하는 클래스
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
    /// 데이터 처리 주요 클래스.
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
            m_Socket = new WebSocketSharp.WebSocket("ws://MYWATTBATBET.asuscomm.com:3000"); // 서버 ip주소
            //m_Socket = new WebSocketSharp.WebSocket("ws://127.0.0.1:80"); // 서버 ip주소
            m_Socket.OnMessage += Recv;
            m_Socket.OnClose += OnClose;
            Connect();
        }

        #region 기본 로직
        /// <summary>
        /// 서버와 연결을 시도하는 함수
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
        /// 새로운 데이터를 받아오는 메서드.
        /// </summary
        private void Recv(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Data);
            m_recvData = JsonConvert.DeserializeObject<ReceivedPacketData>(e.Data);
            m_receivedPacketDatas.Enqueue(new ReceivedPacketData() { eventCode = m_recvData.eventCode, data = m_recvData.data});
        }
        /// <summary>
        /// 서버에 메시지 보낼 때 사용
        /// </summary>
        /// <param name="eventCode"></param>
        public void SendPacket(byte eventCode)
        {
            m_reqData.Clear();
            m_reqData.eventCode = eventCode;
            m_Socket.Send(JsonConvert.SerializeObject(m_reqData));
        }
        /// <summary>
        /// 서버에 메시지 보낼 때 사용
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
        private bool CheckCallBack(ReceivedPacketData recvData)
        {
            if(_callbackDic.ContainsKey(recvData.eventCode))
            {
                _callbackDic[recvData.eventCode].Invoke(recvData.data);
                return true;
            }
            return false;
        }
        private void DataProcess(ReceivedPacketData recvData)
        {
            Dictionary<byte, object> param = recvData.data;
            
            if(CheckCallBack(recvData))
            {
                return;
            }

            switch (recvData.eventCode)
            {
                case (byte)Define.EVENT_CODE.LoginS:
                    // 로그인 처리
                    S_Login.LoginS(param);
                    break;
                case (byte)Define.EVENT_CODE.UserInfoS:
                    S_UserInfo.UserInfoS(param);
                    // 유저 정보를 받음
                    break;
                case (byte)Define.EVENT_CODE.StartMatchingS:
                    // 매칭 시작을 알림
                    S_StartMatching.StartMatchingS(param);
                    break;
                case (byte)Define.EVENT_CODE.MatchingSuccessS:
                    S_MatchingSuccess.MatchingSuccessS(param);
                    break;
                case (byte)Define.EVENT_CODE.MatchingResponseS:
                    S_MatchingResponse.MatchingResponseS(param);
                    break;
                case (byte)Define.EVENT_CODE.MatchingCancelS:
                    S_MatchingCancel.MatchingCancelS(param);
                    break;
                case (byte)Define.EVENT_CODE.MatchingResultS:
                    S_MatchingResult.MatchingResultS(param);
                    break;
                case (byte)Define.EVENT_CODE.UserBattleResponseS:
                    // 상대편이 낸 결과를 받음
                    S_UserBattleResponse.UserBattleResponseS(param);
                    break;
                case (byte)Define.EVENT_CODE.RoundResultS:
                    // 해당 라운드의 결과를 받음
                    S_RoundResult.RoundResultS(param);
                    break;
                case (byte)Define.EVENT_CODE.FriendRequestS:
                    S_FriendRequest.S_FriendRequestS(param);
                    break;
                default:
                    break;
            }
        }

        private void Update()
        {
            if(!m_disconnect)
            {
                if (m_receivedPacketDatas.Count > 0)
                {
                    DataProcess(m_receivedPacketDatas.Dequeue());
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