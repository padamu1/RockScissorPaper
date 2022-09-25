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
            // [0] 상대방이 낸 버튼
            // [1] 상대방이 낸 카드
            // UI 상에 바로 띄워짐
            switch ((Define.ROCK_SCISSOR_PAPER)Convert.ToInt32(param[0]))
            {
                case Define.ROCK_SCISSOR_PAPER.Rock:
                    Debug.Log("상대방이 낸 카드 " + Define.ROCK_SCISSOR_PAPER.Rock.ToString());
                    break;
                case Define.ROCK_SCISSOR_PAPER.Scissor:
                    Debug.Log("상대방이 낸 카드 " + Define.ROCK_SCISSOR_PAPER.Scissor.ToString());
                    break;
                case Define.ROCK_SCISSOR_PAPER.Paper:
                    Debug.Log("상대방이 낸 카드 " + Define.ROCK_SCISSOR_PAPER.Paper.ToString());
                    break;
            }
        }
    }
}
