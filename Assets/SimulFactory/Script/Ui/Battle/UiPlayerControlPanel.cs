using SimulFactory.Game.Event;
using SimulFactory.Manager;
using SimulFactory.System.Common;
using SimulFactory.Ui.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.Ui.Battle
{
    public class UiPlayerControlPanel : MonoBehaviour, IRegistPanel
    {
        [SerializeField] private Transform gameButtonContent;

        private List<UiRSPButton> uiRSPButtons;

        private void OnEnable()
        {
            RegistPanelThisPanel();
            GetGameButton();
        }
        public void RegistPanelThisPanel()
        {
            UiManager.GetInstance().RegistUiPlayerControlPanel(this);
        }
        /// <summary>
        /// 버튼 요소 가져옴
        /// </summary>
        private void GetGameButton()
        {
            uiRSPButtons = new List<UiRSPButton>();

            for(int count = 0; count < gameButtonContent.childCount; count++)
            {
                UiRSPButton uiRSPButton = gameButtonContent.GetChild(count).GetComponent<UiRSPButton>();

                if(uiRSPButton == null)
                {
                    continue;
                }

                uiRSPButton.SetAction(ButtonClicked);
                uiRSPButtons.Add(uiRSPButton);
            }
        }
        /// <summary>
        /// 실제 버튼 눌렸을 때 동작
        /// </summary>
        /// <param name="rspType"></param>
        private void ButtonClicked(Define.ROCK_SCISSOR_PAPER rspType)
        {
            BattleManager.GetInstance().ButtonClicked(rspType);
        }
    }
}
