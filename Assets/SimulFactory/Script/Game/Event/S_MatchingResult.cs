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
            if(!param.ContainsKey(4))
            {
                return;
            }
            switch((Define.MATCH_TYPE)param[4])
            {
                case Define.MATCH_TYPE.Normal:
                    // [0] -> true 승리 , false 패배
                    UserData.GetInstance().GetPvpInfo().Rating = (int)param[1];
                    UserData.GetInstance().GetPvpInfo().WinCount = (int)param[2];
                    UserData.GetInstance().GetPvpInfo().DefeatCount = (int)param[3];
                    UserData.GetInstance().UpdateMatchInfoContext();
                    break;
                case Define.MATCH_TYPE.Multi:
                    UserData.GetInstance().GetMultiPvpInfo().WinCount = (int)param[2];
                    UserData.GetInstance().GetMultiPvpInfo().DefeatCount = (int)param[3];
                    UserData.GetInstance().UpdateMultiMatchInfoContext();
                    break;
                default:
                    break;
            }
            
            Debug.Log("매칭 결과 도착");
            UiManager.GetInstance().StopGameUi();
            UiManager.GetInstance().ResetGameStartButton();
        }
    }
}
