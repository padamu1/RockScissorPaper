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
            showAnimation.OnPlay(LayoutRebuild);
            showAnimation.Append(frame.DOScale(1f, 0.5f).SetEase(Ease.InOutBounce));
            showAnimation.SetAutoKill(false);
            showAnimation.Pause();

            hideAnimation = DOTween.Sequence();
            hideAnimation.Append(frame.DOScale(0.3f, 0.5f).SetEase(Ease.Linear)).OnComplete(ClosePopup);
            hideAnimation.SetAutoKill(false);
            hideAnimation.Pause();
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
