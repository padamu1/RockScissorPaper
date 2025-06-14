using SimulFactory.Manager;
using SimulFactory.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class S_InviteUser
    {
        public static void InviteUserS(Dictionary<byte, object> param)
        {
            Define.RECEIVE_DATA_TYPE receiveDataType = (Define.RECEIVE_DATA_TYPE)(long)param[0];
            switch(receiveDataType)
            {
                case Define.RECEIVE_DATA_TYPE.Me:
                    {
                        PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
                        popupInfo.Type = Define.POPUP_TYPE.ToastPopup;
                        long code = (long)param[1];
                        switch(code)
                        {
                            case 0:
                                popupInfo.Description = "상대방 유저에게 초대 메시지 보냄";
                                break;
                            case 1:
                                popupInfo.Description = "유저가 없음";
                                break;
                            case 2:
                                popupInfo.Description = "유저가 접속중이지 않음";
                                break;
                            case 3:
                                popupInfo.Description = "상대방 유저 게임중임";
                                break;
                        }
                        popupInfo.Top = true;
                        PopupManager.GetInstance().CreatePopup(popupInfo);
                    }
                    break;
                case Define.RECEIVE_DATA_TYPE.Other:
                    {
                        string inviteUserName = (string)param[1];
                        long inviteUserNo = (long)param[2];
                        PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
                        popupInfo.Type = Define.POPUP_TYPE.YesNoPopup;
                        popupInfo.Title = "게임 초대";
                        popupInfo.Description = String.Format("{0} 유저로부터의 게임초대",inviteUserName);
                        popupInfo.YesButtonText = "수락";
                        popupInfo.NoButtonText = "거절";
                        popupInfo.YesButtonAction = delegate { C_InviteReceive.InviteReceiveC(true,inviteUserNo); };
                        popupInfo.NoButtonAction = delegate { C_InviteReceive.InviteReceiveC(false, inviteUserNo); };
                        popupInfo.Top = true;
                        popupInfo.Block = true;
                        PopupManager.GetInstance().CreatePopup(popupInfo);
                    }
                    break;
            }
        }
    }
}
