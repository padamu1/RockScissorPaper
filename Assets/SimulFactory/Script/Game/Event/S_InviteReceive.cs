using SimulFactory.Manager;
using SimulFactory.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class S_InviteReceive
    {
        public static void InviteReceiveS(Dictionary<byte,object> param)
        {

            Define.RECEIVE_DATA_TYPE receiveDataType = (Define.RECEIVE_DATA_TYPE)param[0];
            switch (receiveDataType)
            {
                case Define.RECEIVE_DATA_TYPE.Me:
                    {
                        PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
                        popupInfo.Type = Define.POPUP_TYPE.ToastPopup;
                        long code = (long)param[1];
                        switch (code)
                        {
                            case 0:
                                break;
                            case 1:
                                popupInfo.Description = "접속중이지 않음";
                                break;
                            case 2:
                                popupInfo.Description = "상대방이 초대를 받을 수 없는 상태임";
                                break;
                            case 3:
                                popupInfo.Description = "내가 초대를 받을 수 없는 상태임";
                                break;
                        }
                        popupInfo.Top = true;
                        PopupManager.GetInstance().CreatePopup(popupInfo);
                    }
                    break;
                case Define.RECEIVE_DATA_TYPE.Other:

                    {
                        PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
                        popupInfo.Type = Define.POPUP_TYPE.ToastPopup;
                        long code = (long)param[1];
                        string userName = (string)param[2];
                        switch (code)
                        {
                            case 0:
                                break;
                            case 1:
                                popupInfo.Description = string.Format("{0} 유저가 초대를 거절함",userName);
                                break;
                        }
                        popupInfo.Top = true;
                        PopupManager.GetInstance().CreatePopup(popupInfo);
                    }
                    break;
            }
        }
    }
}
