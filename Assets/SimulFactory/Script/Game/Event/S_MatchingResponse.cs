using SimulFactory.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class S_MatchingResponse
    {
        public static void MatchingResponseS(Dictionary<byte, object> param)
        {
            UiManager.GetInstance().MatchingReponse((int)param[0]);
        }
    }
}
