using SimulFactory.Manager;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SimulFactory.System.Common
{
    public class PopupBase : BaseObject
    {
        [SerializeField] protected Define.POPUP_TYPE popupType;
        [SerializeField] protected RectTransform frame;
        [SerializeField] private Text titleText;
        [SerializeField] private Text descText;
        [SerializeField] private Image block;
        protected Sequence showAnimation;
        protected Sequence hideAnimation;
        private void Start()
        {
            showAnimation = DOTween.Sequence();
            showAnimation.Append(frame.DOScale(1f, 0.5f).From(0.5f).SetEase(Ease.Linear));
            showAnimation.SetAutoKill(false);
            showAnimation.Pause();

            hideAnimation = DOTween.Sequence();
            hideAnimation.Append(frame.DOScale(0.3f, 0.5f).From(1f).SetEase(Ease.Linear)).OnComplete(ClosePopup);
            hideAnimation.SetAutoKill(false);
            hideAnimation.Pause();

            // 첫 실행시 애니메이션 재생을 위함
            showAnimation.Restart();
        }
        protected virtual void OnEnable()
        {
            showAnimation.Restart();
        }
        protected void LayoutRebuild()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(frame);
        }
        public virtual void SetInfo(PopupManager.PopupInfo popupInfo)
        {
            if (titleText != null)
            {
                titleText.text = popupInfo.Title;
            }
            if (descText != null)
            {
                descText.text = popupInfo.Description;
                descText.gameObject.SetActive(popupInfo.Description != "");
            }
            if (block != null)
            {
                block.enabled = popupInfo.Block;
            }
        }
        protected virtual void ClosePopup()
        {
            gameObject.SetActive(false);
        }
    }
}
