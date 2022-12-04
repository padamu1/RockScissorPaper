using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using SimulFactory.Game.Event;

namespace SimulFactory.Manager
{    
    public class WorldManager : MonoSingleton<WorldManager>
    {
        /// <summary>
        /// 오브젝트 풀 설정
        /// </summary>
        public void Start()
        {
            ObjectPoolManager.GetInstance().SetPool(Resources.Load<GameObject>("Ui/Popup/MainPopup"),Define.MAINPOPUP_SET_COUNT);
            ObjectPoolManager.GetInstance().SetPool(Resources.Load<GameObject>("Ui/Popup/ToastPopup"),Define.TOASTPOPUP_SET_COUNT);
        }
        /// <summary>
        /// 서버에서 받은 메시지 처리
        /// </summary>
        /// <param name="recvData"></param>
        public void DataProcess(ReceivedPacketData recvData)
        {
            Dictionary<byte, object> param = recvData.data;

            if (SocketManager.GetInstance().CheckCallBack(recvData))
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
                    // 친구 요청
                    S_FriendRequest.FriendRequestS(param);
                    break;
                case (byte)Define.EVENT_CODE.FriendRemoveS:
                    // 친구 삭제
                    S_FriendRemove.FriendRemoveS(param);
                    break;
                case (byte)Define.EVENT_CODE.FriendReceiveS:
                    // 친구 요청 수락
                    S_FriendReceive.FriendReceiveS(param);
                    break;
                case (byte)Define.EVENT_CODE.FriendDataS:
                    // 친구 데이터 받기
                    S_FriendData.FriendDataS(param);
                    break;
                case (byte)Define.EVENT_CODE.ChatS:
                    break;
                case (byte)Define.EVENT_CODE.InviteUserS:
                    break;
                case (byte)Define.EVENT_CODE.InviteReceiveS:
                    break;
                default:
                    break;
            }
        }
    }
}
