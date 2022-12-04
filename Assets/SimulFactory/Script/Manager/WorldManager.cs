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
        /// ������Ʈ Ǯ ����
        /// </summary>
        public void Start()
        {
            ObjectPoolManager.GetInstance().SetPool(Resources.Load<GameObject>("Ui/Popup/MainPopup"),Define.MAINPOPUP_SET_COUNT);
            ObjectPoolManager.GetInstance().SetPool(Resources.Load<GameObject>("Ui/Popup/ToastPopup"),Define.TOASTPOPUP_SET_COUNT);
        }
        /// <summary>
        /// �������� ���� �޽��� ó��
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
                    // �α��� ó��
                    S_Login.LoginS(param);
                    break;
                case (byte)Define.EVENT_CODE.UserInfoS:
                    S_UserInfo.UserInfoS(param);
                    // ���� ������ ����
                    break;
                case (byte)Define.EVENT_CODE.StartMatchingS:
                    // ��Ī ������ �˸�
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
                    // ������� �� ����� ����
                    S_UserBattleResponse.UserBattleResponseS(param);
                    break;
                case (byte)Define.EVENT_CODE.RoundResultS:
                    // �ش� ������ ����� ����
                    S_RoundResult.RoundResultS(param);
                    break;
                case (byte)Define.EVENT_CODE.FriendRequestS:
                    // ģ�� ��û
                    S_FriendRequest.FriendRequestS(param);
                    break;
                case (byte)Define.EVENT_CODE.FriendRemoveS:
                    // ģ�� ����
                    S_FriendRemove.FriendRemoveS(param);
                    break;
                case (byte)Define.EVENT_CODE.FriendReceiveS:
                    // ģ�� ��û ����
                    S_FriendReceive.FriendReceiveS(param);
                    break;
                case (byte)Define.EVENT_CODE.FriendDataS:
                    // ģ�� ������ �ޱ�
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
