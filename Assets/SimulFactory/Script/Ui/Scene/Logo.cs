using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using SimulFactory.Manager;

namespace SimulFactory.Ui.Logo
{
    public class Logo : MonoBehaviour
    {
        public Image logoFrame;
        public Image logoImage;
        public TMP_Text logoText;
        private Sequence showAnimation;
        private Sequence hideAnimation;

        private void Awake()
        {
            Managers.GetInstance();

            showAnimation = DOTween.Sequence();
            showAnimation.Append(logoImage.DOFade(1f, 2f).From(0f));
            showAnimation.Insert(0f, logoFrame.DOFade(1f, 2f).From(0f));
            showAnimation.Insert(0f,logoText.DOFade(1f, 2f).From(0f));
            showAnimation.SetAutoKill(false);
            showAnimation.OnComplete(HideAnimationStart);
            showAnimation.Pause();

            hideAnimation = DOTween.Sequence();
            hideAnimation.Append(logoImage.DOFade(0f, 2f).From(1f));
            hideAnimation.Insert(0f, logoFrame.DOFade(0f, 2f).From(1f));
            hideAnimation.Insert(0f,logoText.DOFade(0f, 2f).From(1f));
            hideAnimation.SetAutoKill(false);
            hideAnimation.OnComplete(LoadLogin);
            hideAnimation.Pause();
        }
        private void Start()
        {
            showAnimation.Restart();
        }
        private void HideAnimationStart()
        {
            hideAnimation.Restart();
        }
        private void LoadLogin()
        {
            DOTween.KillAll();
            Managers.GetInstance().LoadScene("Login");
        }
    }
}
