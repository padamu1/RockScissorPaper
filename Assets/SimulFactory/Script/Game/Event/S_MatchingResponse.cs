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
            switch (Convert.ToInt32(param[0]))
            {
                case 0:
                    UiManager.GetInstance().MatchResultUiActivate();
                    BattleManager.GetInstance().st
                    break;
                case 1:
                    Debug.Log("매칭 시작 실패");
                    break;
            }
        }
    }
}
