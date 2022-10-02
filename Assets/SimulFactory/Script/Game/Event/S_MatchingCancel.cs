using SimulFactory.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class S_MatchingCancel
    {
        public static void MatchingCancelS(Dictionary<byte,object> param)
        {
            Debug.Log("매칭 취소 성공");
            UiManager.GetInstance().ResetGameStartButton();
        }
    }
}
