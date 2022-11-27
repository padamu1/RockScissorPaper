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
                        Debug.Log("模备夸没单捞磐甸绢咳");
                    }
                    break;
            }
        }
    }
}
