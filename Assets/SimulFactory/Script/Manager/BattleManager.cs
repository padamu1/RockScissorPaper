using SimulFactory.Context;
using SimulFactory.Context.Bean;
using SimulFactory.Game.Event;
using SimulFactory.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;

namespace SimulFactory.Manager
{
    public class BattleManager : MonoSingleton<BattleManager>
    {
        private List<string> matchUserInfos;
        private Define.ROCK_SCISSOR_PAPER clickedButton;
        private void Awake()
        {
            matchUserInfos = new List<string>();
        }
        public void SetMatchUserInfos(List<string> matchUserInfos)
        {
            matchUserInfos.Remove(UserData.GetInstance().GetUserName());
            this.matchUserInfos = matchUserInfos;
        }
        public List<string> GetMatchUserInfos()
        {
            return matchUserInfos;
        }
        public void ButtonClicked(Define.ROCK_SCISSOR_PAPER buttonType)
        {
            clickedButton = buttonType;
            C_UserBattleButtonClicked.UserBattleButtonClickedC((int)buttonType);
        }
        public void CompareResult(Define.ROCK_SCISSOR_PAPER winUserResult)
        {
            if(winUserResult == clickedButton)
            {
                DOTweenManager.GetInstance().StartDOTween();
                Debug.Log("내가 이김");
            }
            else if(winUserResult == Define.ROCK_SCISSOR_PAPER.Tie)
            {
                Debug.Log(" 비김 ");
            }
            else
            {
                Debug.Log(" 내가 짐 ");
            }
        }
    }
}
