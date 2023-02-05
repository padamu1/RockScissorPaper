using DG.Tweening;
using SimulFactory.Game.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingProcessObject : MonoBehaviour
{
    [SerializeField] private RectTransform rotateRect;
    private Sequence rotateAnimation;
    private void Awake()
    {
        rotateAnimation.Append(rotateRect.DOLocalRotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360).SetLoops(-1).SetRelative(true).SetEase(Ease.Linear));
        rotateAnimation.SetAutoKill(false);
        rotateAnimation.Pause();
    }
    public void OnEnable()
    {
        rotateAnimation.Restart();
    }
    public void OnDisable()
    {
        rotateAnimation.Pause();
    }
    public void StopMatching()
    {
        C_MatchingCancel.MatchingCancelC();
    }
}
