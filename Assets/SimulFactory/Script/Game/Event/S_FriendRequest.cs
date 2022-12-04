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
            Define.RECEIVE_DATA_TYPE type = (Define.RECEIVE_DATA_TYPE)(long)param[0];
            switch (type)
            {
                case Define.RECEIVE_DATA_TYPE.Me:
                    bool isRequested = (bool)param[1];
                    if (isRequested)
                    {
                        Debug.Log("친구 요청 성공");
                    }
                    else
                    {
                        Debug.Log("친구 요청 실패");
                    }
                    break;
                case Define.RECEIVE_DATA_TYPE.Other:
                    List<FriendRequestDto> friendRequestDtoList = JsonConvert.DeserializeObject<List<FriendRequestDto>>((string)param[1]);
                    foreach(FriendRequestDto data in friendRequestDtoList)
                    {
                        PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
                        popupInfo.Type = Define.POPUP_TYPE.ToastPopup;
                        popupInfo.Description = string.Format("{0} 로 부터 친구 요청 들어옴", data.FriendName);
                        popupInfo.Top = true;
                        PopupManager.GetInstance().CreatePopup(popupInfo);
                        //친구요청창 띄움
                        //FriendRequestPopup.GetInstance().GetPopup();
                        Debug.Log("친구요청데이터들어옴");
                    }
                    break;
            }
        }
    }
}
