using SimulFactory.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

namespace SimulFactory.Game.Event
{
    public class S_MatchingSuccess
    {
        public static void MatchingSuccessS(Dictionary<byte,object> param)
        {
            List<object> users = (List<object>)param[0];
            foreach(object user in users)
            {
                Debug.Log(user.ToString());
            }
            BattleManager.GetInstance().SetMatchUserInfos(users.Select(x => x.ToString()).ToList());
            UiManager.GetInstance().MatchSuccess();
        }
    }
}
