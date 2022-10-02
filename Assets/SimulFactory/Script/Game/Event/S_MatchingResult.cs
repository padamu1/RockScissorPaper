using SimulFactory.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class S_MatchingResult
    {
        public static void MatchingResultS(Dictionary<byte,object> param)
        {
            Debug.Log("매칭 결과 도착");
            UiManager.GetInstance().StopGameUi();
            UiManager.GetInstance().ResetGameStartButton();
            UiManager.GetInstance().GetBattleManager().ButtonDeactivate();
        }
    }
}
