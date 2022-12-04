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
    public class S_FriendReceive
    {
        public static void FriendReceiveS(Dictionary<byte, object> param)
        {
            Define.FRIEND_RECEIVE_DATA_TYPE type = (Define.FRIEND_RECEIVE_DATA_TYPE)(long)param[0];
            switch (type)
            {
                case Define.FRIEND_RECEIVE_DATA_TYPE.Me:
                    bool isReceived = (bool)param[1];
                    if (isReceived)
                    {
                        Debug.Log("模备 夸没 荐遏");
                    }
                    else
                    {
                        Debug.Log("模备 夸没 芭例");
                    }
                    break;
                case Define.FRIEND_RECEIVE_DATA_TYPE.Other:
                    List<FriendRequestDto> friendRequestDtoList = JsonConvert.DeserializeObject<List<FriendRequestDto>>((string)param[1]);
                    foreach (FriendRequestDto data in friendRequestDtoList)
                    {
                        Debug.Log("模备夸没荐遏窃");
                    }
                    break;
            }
        }
    }
}
