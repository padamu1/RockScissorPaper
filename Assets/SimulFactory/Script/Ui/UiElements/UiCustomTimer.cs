using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

namespace SimulFactory.Ui.UiElements
{
    public class UiCustomTimer : MonoBehaviour
    {
        [SerializeField] private Image slicedImage;
        private Action customAction;
        private bool autokill;
        private void OnDisable()
        {
            // 닫힐때 설정된 모든 트윈을 제거
            slicedImage.DOPause();
            slicedImage.DOKill();
        }
        public void SetTimer(float setTime, Action customAction, bool autokill = true)
        {
            this.gameObject.SetActive(true);
            slicedImage.DOPause();
            this.customAction = customAction;
            this.autokill = autokill;
            slicedImage.DOFillAmount(0f, setTime - 0.5f).From(1f).SetEase(Ease.Linear).OnComplete(CompleteAction);
        }
        private void CompleteAction()
        {
            customAction?.Invoke();
            if (autokill)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

}