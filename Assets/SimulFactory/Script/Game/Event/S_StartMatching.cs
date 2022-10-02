using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class S_StartMatching
    {
        public static void StartMatchingS(Dictionary<byte,object> param)
        {
            bool isMatchStarted = (bool)param[0];
            if (isMatchStarted)
            {
                Debug.Log("매칭 시작 성공");
            }
            else
            {
                Debug.Log("매칭 시작 실패");
            }
        }
    }
}
