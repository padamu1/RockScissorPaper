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
            slicedImage.DORewind();
        }
        public void SetTimer(float setTime, Action customAction, bool autokill = true)
        {
            this.gameObject.SetActive(true);
            this.customAction = customAction;
            slicedImage.DOFillAmount(0f, setTime).From(1f).OnComplete(CompleteAction);
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