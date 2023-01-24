using SimulFactory.Manager;
using SimulFactory.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class S_Chat
    {
        public static void ChatS(Dictionary<byte,object> param)
        {
            Define.CHAT_TYPE chatType = (Define.CHAT_TYPE)(int)param[0];
            switch (chatType)
            {
                case Define.CHAT_TYPE.Toast:
                    {
                        PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
                        popupInfo.Type = Define.POPUP_TYPE.ToastPopup;
                        popupInfo.Description = (string)param[2];
                        popupInfo.Top = true;
                        PopupManager.GetInstance().CreatePopup(popupInfo);
                    }
                    break;
                case Define.CHAT_TYPE.None:
                    {
                        if ((string)param[1] == UserData.GetInstance().GetUserName())
                        {
                            ChattingManager.GetInstance().MakeMyMessage((string)param[1], (string)param[2]);
                        }
                        else
                        {
                            ChattingManager.GetInstance().MakeOtherMessage((string)param[1], (string)param[2]);
                        }
                    }
                    break;
                case Define.CHAT_TYPE.Whisper:
                    {
                        if ((string)param[1] == UserData.GetInstance().GetUserName())
                        {
                            ChattingManager.GetInstance().MakeMyWhisper((string)param[1], (string)param[2]);
                        }
                        else
                        {
                            ChattingManager.GetInstance().MakeOtherWhisper((string)param[1], (string)param[2]);
                        }
                    }
                    break;
            }
        }
    }
}
