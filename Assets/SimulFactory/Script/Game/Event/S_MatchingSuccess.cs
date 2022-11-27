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
            List<string> Users = JsonConvert.DeserializeObject<List<string>>(param[0].ToString());
            foreach(string User in Users)
            {
                Debug.Log(User);
            }

            UiManager.GetInstance().MatchSuccess();
        }
    }
}
