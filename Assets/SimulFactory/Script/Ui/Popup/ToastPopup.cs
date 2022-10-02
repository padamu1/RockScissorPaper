using SimulFactory.Manager;
using SimulFactory.System.Common;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SimulFactory.Ui.Popup
{
    public class ToastPopup : PopupBase
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            Invoke("HideAnimationStart", 1f);
        }
        public override void SetInfo(PopupManager.PopupInfo popupInfo)
        {
            base.SetInfo(popupInfo);
        }
        private void HideAnimationStart()
        {
            hideAnimation.Restart();
        }
    }
}
