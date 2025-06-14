using SimulFactory.System.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class UiRSPButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Define.ROCK_SCISSOR_PAPER rspType;
    private Action<Define.ROCK_SCISSOR_PAPER> action;

    //public float ButtonColorChangeTime = 0.5f;
    //public Color ButtonChangeColor = Color.gray;

    // ���� ��ư�� Ÿ�� ��ȯ
    public Define.ROCK_SCISSOR_PAPER GetRSPType() => rspType;

    // ���� ��ư ��ȯ
    public void SetAction(Action<Define.ROCK_SCISSOR_PAPER> action) => this.action = action;
    public void ButtonClickedAction()
    {
        action?.Invoke(rspType);
        //gameObject.GetComponent<Image>().DOColor(ButtonChangeColor, ButtonColorChangeTime);
    }
}
