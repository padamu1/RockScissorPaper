using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiButton : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        // �ִϸ����� ���� �ʱ�ȭ
        animator.keepAnimatorControllerStateOnDisable = false;
    }
}
