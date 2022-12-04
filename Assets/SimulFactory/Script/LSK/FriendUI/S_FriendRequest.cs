using Newtonsoft.Json;
using SimulFactory.Manager;
using SimulFactory.System.Common;
using SimulFactory.System.Common.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SimulFactory.Game.Event;
namespace SimulFactory.Game.Event
{
    public class S_FriendRequest
    {
        public static void S_FriendRequestS(Dictionary<byte, object> param)
        {
            Define.FRIEND_RECEIVE_DATA_TYPE type = (Define.FRIEND_RECEIVE_DATA_TYPE)(long)param[0];
            switch (type)
            {
                case Define.FRIEND_RECEIVE_DATA_TYPE.Me:
                    bool isRequested = (bool)param[1];
                    if (isRequested)
                    {
                        Debug.Log("模备 夸没 己傍");
                    }
                    else
                    {
                        Debug.Log("模备 夸没 角菩");
                    }
                    break;
                case Define.FRIEND_RECEIVE_DATA_TYPE.Other:
                    List<FriendRequestDto> friendRequestDtoList = JsonConvert.DeserializeObject<List<FriendRequestDto>>((string)param[1]);
                    foreach(FriendRequestDto data in friendRequestDtoList)
                    {
                        PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
                        popupInfo.Type = Define.POPUP_TYPE.ToastPopup;
                        popupInfo.Description = "模备 夸没 甸绢咳";
                        popupInfo.Top = true;
                        PopupManager.GetInstance().CreatePopup(popupInfo);
                        //模备夸没芒 剁框
                        //FriendRequestPopup.GetInstance().GetPopup();
                        Debug.Log("模备夸没单捞磐甸绢咳");
                    }
                    break;
            }
        }
    }
}
