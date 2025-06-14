﻿using SimulFactory.Manager;
using SimulFactory.System.Common;
using System.Collections.Generic;

namespace SimulFactory.Game.Event
{
    public class S_Login
    {
        public static void LoginS(Dictionary<byte,object> param)
        {
            Dictionary<string, object> message = new Dictionary<string, object>(); // 주석
            message.Add("result", param[0]);
            if ((bool)param[0])
            {
                message.Add("userNo", param[1]);
            }
            EventManager.GetInstance().TriggerEvent(Define.UNITY_EVENT.Login, message);
        }
    }
}
