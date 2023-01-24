using SimulFactory.Manager;
using SimulFactory.System.Common;
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
            // [0] -> true 승리 , false 패배
            UserData.GetInstance().GetPvpInfo().Rating = Convert.ToInt32(param[1]);
            UserData.GetInstance().GetPvpInfo().WinCount = Convert.ToInt32(param[2]);
            UserData.GetInstance().GetPvpInfo().DefeatCount = Convert.ToInt32(param[3]);
            UserData.GetInstance().UpdateMatchInfoContext();
            Debug.Log("매칭 결과 도착");
            UiManager.GetInstance().StopGameUi();
            UiManager.GetInstance().ResetGameStartButton();
        }
    }
}
