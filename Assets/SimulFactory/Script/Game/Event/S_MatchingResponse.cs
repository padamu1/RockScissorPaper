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
        public static void MatchingResponseS(Dictionary<byte,object> param)
        {
            Debug.Log("매칭 시작 성공");
        }
    }
}
