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
            SetButtonAction();
        }
        public void RegistPanelThisPanel()
        {
            UiManager.GetInstance().RegistUiPlayerControlPanel(this);
        }
        /// <summary>
        /// ��ư ��� ������
        /// </summary>
        private void GetGameButton()
        {
            uiRSPButtons = new List<UiRSPButton>();

            for(int count = 0; count < uiRSPButtons.Count; count++)
            {
                UiRSPButton uiRSPButton = gameButtonContent.GetChild(count).GetComponent<UiRSPButton>();

                if(uiRSPButton == null)
                {
                    continue;
                }

                uiRSPButtons.Add(uiRSPButton);
            }
        }
        /// <summary>
        /// ���� ��ư ������ �� ���� ����
        /// </summary>
        private void SetButtonAction() => uiRSPButtons.ForEach(
            uiRSPButton => 
            uiRSPButton.GetButton().onClick.AddListener(delegate { 
                ButtonClicked(uiRSPButton.GetRSPType()); 
            }));
        /// <summary>
        /// ���� ��ư ������ �� ����
        /// </summary>
        /// <param name="rspType"></param>
        private void ButtonClicked(Define.ROCK_SCISSOR_PAPER rspType)
        {
            BattleManager.GetInstance().ButtonClicked(rspType);
        }
    }
}
