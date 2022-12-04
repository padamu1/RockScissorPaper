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

namespace SimulFactory.Game.Event
{
    public class S_FriendRemove
    {
        public static void FriendRemoveS(Dictionary<byte, object> param)
        {
            Define.FRIEND_RECEIVE_DATA_TYPE type = (Define.FRIEND_RECEIVE_DATA_TYPE)(long)param[0];
            switch (type)
            {
                case Define.FRIEND_RECEIVE_DATA_TYPE.Me:
                    bool isRequested = (bool)param[1];
                    if (isRequested)
                    {
                        Debug.Log("模备 昏力 己傍");
                    }
                    else
                    {
                        Debug.Log("模备 昏力 角菩");
                    }
                    break;
                case Define.FRIEND_RECEIVE_DATA_TYPE.Other:
                    List<FriendRequestDto> friendRequestDtoList = JsonConvert.DeserializeObject<List<FriendRequestDto>>((string)param[1]);
                    foreach (FriendRequestDto data in friendRequestDtoList)
                    {
                        Debug.Log("惑措规捞 模备昏力窃");
                    }
                    break;
            }
        }
    }
}
