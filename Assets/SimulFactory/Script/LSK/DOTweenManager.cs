using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace SimulFactory.Manager
{
    public class DOTweenManager : MonoSingleton<DOTweenManager>
    {
        public GameObject obj;
        public Vector3 vec;
        public float time;
        [Tooltip("0: DOMove, 1: DOScale")]
        public int mode = 0;
        public float waitTime = 1.8f;

        IEnumerator SwitchMode(int mode)
        {
            obj.SetActive(true);
            switch (mode)
            {
                case 0:
                    obj.transform.DOMove(vec, time);
                    yield return null;
                    break;
                case 1:
                    obj.transform.localScale = new Vector3(0, 0, 0);
                    obj.transform.DOScale(vec, time);
                    yield return new WaitForSeconds(waitTime);
                    obj.transform.DOScale(new Vector3(0, 0, 0), time);
                    break;
            }
        }

        public void StartDOTween()
        {
            StartCoroutine(SwitchMode(mode));
        }

        private void Start()
        {
            StartDOTween();
        }
    }
}