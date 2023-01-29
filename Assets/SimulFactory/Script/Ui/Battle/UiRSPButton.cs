using SimulFactory.System.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiRSPButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Define.ROCK_SCISSOR_PAPER rspType;
    private Action<Define.ROCK_SCISSOR_PAPER> action;

    // 현재 버튼의 타입 반환
    public Define.ROCK_SCISSOR_PAPER GetRSPType() => rspType;

    // 현재 버튼 반환
    public void SetAction(Action<Define.ROCK_SCISSOR_PAPER> action) => this.action = action;
    public void ButtonClickedAction()
    {
        action?.Invoke(rspType);
    }
}
