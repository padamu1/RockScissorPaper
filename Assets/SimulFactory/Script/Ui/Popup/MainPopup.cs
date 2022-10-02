using SimulFactory.Manager;
using SimulFactory.System.Common;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SimulFactory.Ui.Popup
{
    public class MainPopup : PopupBase
    {
        [SerializeField] private Text yesButtonText;
        [SerializeField] private Action yesButtonAction;
        [SerializeField] private Text noButtonText;
        [SerializeField] private Action noButtonAction;
        public override void SetInfo(PopupManager.PopupInfo popupInfo)
        {
            base.SetInfo(popupInfo);

            if (popupInfo.YesButtonAction != null)
            {
                yesButtonText.text = popupInfo.YesButtonText;
                yesButtonAction = popupInfo.YesButtonAction;
            }
            noButtonText.text = popupInfo.NoButtonText;
            noButtonAction = popupInfo.NoButtonAction;

            showAnimation.Restart();
        }
        public void YesButtonClicked()
        {
            yesButtonAction?.Invoke();
            hideAnimation.Restart();
        }
        public void NoButtonClicked()
        {
            noButtonAction?.Invoke();
            hideAnimation.Restart();
        }
    }
}
