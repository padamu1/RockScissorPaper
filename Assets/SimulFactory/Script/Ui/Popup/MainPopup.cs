using SimulFactory.Manager;
using SimulFactory.System.Common;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;
using TMPro;

namespace SimulFactory.Ui.Popup
{
    public class MainPopup : PopupBase
    {
        [SerializeField] private Text yesButtonText;
        [SerializeField] private Text noButtonText;
        [SerializeField] private Text warningText;
        [SerializeField] private TMP_InputField inputField;
        private Action yesButtonAction;
        private Action noButtonAction;
        private Action<string> inputAction;
        public override void SetInfo(PopupManager.PopupInfo popupInfo)
        {
            base.SetInfo(popupInfo);
            switch(popupInfo.Type)
            {
                case Define.POPUP_TYPE.YesNoPopup:
                    inputField.gameObject.SetActive(false);
                    break;
                case Define.POPUP_TYPE.InputPopup:
                    inputField.gameObject.SetActive(true);
                    inputAction = popupInfo.InputAction;
                    yesButtonText.text = popupInfo.YesButtonText;
                    break;
            }

            if (popupInfo.YesButtonAction != null)
            {
                yesButtonText.text = popupInfo.YesButtonText;
                yesButtonAction = popupInfo.YesButtonAction;
            }
            warningText.text = popupInfo.WarningText;
            warningText.gameObject.SetActive(popupInfo.WarningText !=String.Empty);
            noButtonText.text = popupInfo.NoButtonText;
            noButtonAction = popupInfo.NoButtonAction;
        }
        public void YesButtonClicked()
        {
            if(inputField.gameObject.activeSelf == false)
            {
                yesButtonAction?.Invoke();
            }
            else
            {
                if(inputField.text == String.Empty)
                {
                    PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
                    popupInfo.Type = Define.POPUP_TYPE.ToastPopup;
                    popupInfo.Description = "내용이 없습니다.";
                    popupInfo.Top = true;
                    PopupManager.GetInstance().CreatePopup(popupInfo);
                    return;
                }
                inputAction.Invoke(inputField.text);
                inputField.text = String.Empty;
            }
            hideAnimation.Restart();
        }
        public void NoButtonClicked()
        {
            noButtonAction?.Invoke();
            hideAnimation.Restart();
        }
    }
}
