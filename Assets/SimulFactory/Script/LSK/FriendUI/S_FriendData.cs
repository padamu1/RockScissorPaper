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
    public class S_FriendData
    {
        public static void FriendDataS(Dictionary<byte, object> param)
        {
            List<FriendDto> friendDtoList = JsonConvert.DeserializeObject<List<FriendDto>>((string)param[0]);

            foreach(FriendDto data in friendDtoList)
            {
                UserData.GetInstance().SetUserFriendList(data);
            }
        }
    }
}
