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
    public class S_MatchingResponse
    {
        public static void MatchingResponseS(Dictionary<byte, object> param)
        {
            switch (Convert.ToInt32(param[0]))
            {
                case 0:
                    UiManager.GetInstance().MatchResultUiActivate();
                    break;
                case 1:
                    PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
                    popupInfo.Type = Define.POPUP_TYPE.ToastPopup;
                    popupInfo.Description = string.Format("잠시후 다시 시도해주세요");
                    popupInfo.Top = true;
                    PopupManager.GetInstance().CreatePopup(popupInfo);
                    Debug.Log("매칭 시작 실패");
                    break;
            }
        }
    }
}
