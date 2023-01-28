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
        public void ButtonClicked(int buttonType)
        {
            UiManager.GetInstance().GetUiPlayerResultPanel().SetMyResult(buttonType);
            C_UserBattleButtonClicked.UserBattleButtonClickedC(buttonType);
        }
    }
}
