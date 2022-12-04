using SimulFactory.Manager;
using SimulFactory.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class S_Chat
    {
        public static void ChatS(Dictionary<byte,object> param)
        {
            Define.CHAT_TYPE chatType = (Define.CHAT_TYPE)(long)param[0];
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
                    //param.Add(1, sendUser);
                    //param.Add(2, chatText);
                    //PcListInstance.GetInstance().SendPacket(new EventData((int)Define.EVENT_CODE.ChatS, param));
                    //break;
                case Define.CHAT_TYPE.Whisper:
                    //param.Add(1, sendUser);
                    //param.Add(2, chatText);
                    //param.Add(3, targetName);
                    //PcListInstance.GetInstance().SendPacket(new EventData((int)Define.EVENT_CODE.ChatS, param));
                    break;
            }
        }
    }
}
