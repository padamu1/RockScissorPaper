using SimulFactory.Game.Event;
using SimulFactory.Manager;
using SimulFactory.System.Common;
using SimulFactory.Ui.Base;
using SimulFactory.Ui.UiElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.Ui.Battle
{
    public class UiPlayerControlPanel : MonoBehaviour, IRegistPanel
    {
        [SerializeField] private Transform gameButtonContent;
        [SerializeField] private UiCustomTimer uiCustomTimer;

        private List<UiRSPButton> uiRSPButtons;

        private void OnEnable()
        {
            RegistPanelThisPanel();
            GetGameButton();
            StartTimer();
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
            BattleManager.GetInstance().ButtonClicked((int)rspType);
        }
        /// <summary>
        /// 10초 타이머 적용
        /// </summary>
        public void StartTimer()
        {
            uiCustomTimer.SetTimer(Define.USER_RESULT_WAIT_TIME, EndTimerAction, false);
        }
        /// <summary>
        /// 타이머가 종료되었을 때 유저 결과가 세팅이 안되어있으면 임의의 값을 서버로 보냄
        /// </summary>
        public void EndTimerAction()
        {
            if(!UiManager.GetInstance().GetUiPlayerResultPanel().GetMyResult())
            {
                int randomValue = Random.Range(0, 3);
                BattleManager.GetInstance().ButtonClicked(randomValue);
            }
        }
    }
}
