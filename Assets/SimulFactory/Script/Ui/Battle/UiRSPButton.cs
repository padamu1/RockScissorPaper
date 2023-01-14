using SimulFactory.System.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiRSPButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Define.ROCK_SCISSOR_PAPER rspType;

    // ���� ��ư�� Ÿ�� ��ȯ
    public Define.ROCK_SCISSOR_PAPER GetRSPType() => rspType;

    // ���� ��ư ��ȯ
    public Button GetButton() => button;
}
