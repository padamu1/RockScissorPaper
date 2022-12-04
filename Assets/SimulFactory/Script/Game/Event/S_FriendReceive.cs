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
            Define.RECEIVE_DATA_TYPE type = (Define.RECEIVE_DATA_TYPE)(long)param[0];
            switch (type)
            {
                case Define.RECEIVE_DATA_TYPE.Me:
                    {
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
                    }
                case Define.RECEIVE_DATA_TYPE.Other:
                    {
                        string userName = (string)param[1];
                        bool isReceived = (bool)param[2];
                        if (isReceived)
                        {
                            Debug.LogFormat("{0} 模备 夸没 荐遏",userName);
                        }
                        else
                        {
                            Debug.LogFormat("{0} 模备 夸没 芭例",userName);
                        }
                        break;
                    }
            }
        }
    }
}
