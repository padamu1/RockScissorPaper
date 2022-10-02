using SimulFactory.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class S_RoundResult
    {
        public static void RoundResultS(Dictionary<byte,object> param)
        {
            Debug.Log("팀 넘버 : " + Convert.ToInt32(param[0]) + " 가 이김");
            UiManager.GetInstance().GetBattleManager().ButtonActivate();
            // 라운드 결과가 들어옴
            // [0] : 승패 여부 각 팀 넘버 비겼을 경우 3
            // [1] : 이번 라운드에 사용한 카드 정보 -> 해당 카드를 바로 없애야함
            // [2] : 상대방이 현재 보유한 카드 수량
            // 팝업 알림으로 표시 -> "승리" -> 승리 카운트 +1
            // 패배시 상대편의 승리카운트가 +1
        }
    }
}
