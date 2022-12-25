using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiButton : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        // 애니메이터 상태 초기화
        animator.keepAnimatorControllerStateOnDisable = false;
    }
}
