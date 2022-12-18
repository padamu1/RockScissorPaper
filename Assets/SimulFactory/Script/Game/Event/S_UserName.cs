using SimulFactory.Manager;
using SimulFactory.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class S_UserName
    {
        public static void UserNameS(Dictionary<byte,object> param)
        {
            PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
            popupInfo.Type = Define.POPUP_TYPE.ToastPopup;
            long code = (long)param[0];
            switch (code)
            {
                case 0:
                    UserData.GetInstance().SetUserName((string)param[1]);
                    popupInfo.Description = "닉네임이 변경되었습니다.";
                    break;
                case 1:
                    popupInfo.Description = "중복된 닉네임입니다.";
                    break;
                case 2:
                    popupInfo.Description = "특수문자를 포함할 수 없습니다.";
                    break;
                case 3:
                    popupInfo.Description = "닉네임 몇자까지 가능한지. 비속어 포함된 닉네임불가, ";
                    break;
            }
            popupInfo.Top = true;
            PopupManager.GetInstance().CreatePopup(popupInfo);

        }



    }
}
