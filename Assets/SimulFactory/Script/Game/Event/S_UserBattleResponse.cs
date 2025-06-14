using Newtonsoft.Json;
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
    public class S_UserBattleResponse
    {
        public static void UserBattleResponseS(Dictionary<byte, object> param)
        {
            // 유저의 배틀 결과를 시각적으로 보여주기 위함. 결과 전에 먼저 도착해서 UI에 띄워짐
            // UI 상에 바로 띄워짐
            List<object> results = (List<object>)param[0];
            for(int count = 0; count < results.Count; count++)
            {
                List<object> userResultData = (List<object>)results[count];
                UiManager.GetInstance().GetUiPlayerResultPanel().SetResult((string)userResultData[0], (int)userResultData[1]);
            }
        }
    }
}
