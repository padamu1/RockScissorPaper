using SimulFactory.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class S_MatchingSuccess
    {
        public static void MatchingSuccessS(Dictionary<byte,object> param)
        {
            Debug.Log("매칭 성공");
            UiManager.GetInstance().MatchSuccess();
        }
    }
}
