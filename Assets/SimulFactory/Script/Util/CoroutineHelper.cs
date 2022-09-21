using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.Script.Util
{
    public class CoroutineHelper : MonoSingleton<CoroutineHelper>
    {
        private Dictionary<float, WaitForSeconds> m_waitForSecondDic;
        private List<Coroutine> m_CoroutineList;
        private void Awake()
        {
            m_waitForSecondDic = new Dictionary<float, WaitForSeconds>();
            m_CoroutineList = new List<Coroutine>();
        }
        public static WaitForSeconds GetWaitForSeconds(float waitForSecond)
        {
            if(!GetInstance().m_waitForSecondDic.ContainsKey(waitForSecond))
            {
                GetInstance().m_waitForSecondDic.Add(waitForSecond, new WaitForSeconds(waitForSecond));
            }

            return GetInstance().m_waitForSecondDic[waitForSecond];
        }
        public static Coroutine StartLogoStopCoroutine(IEnumerator enumerator)
        {
            Coroutine coroutine = GetInstance().StartCoroutine(enumerator);
            GetInstance().m_CoroutineList.Add(coroutine);
            return coroutine;
        }
        public static void StopLogoStopCoroutine(Coroutine coroutine)
        {
            if(GetInstance().m_CoroutineList.Contains(coroutine))
            {
                GetInstance().StopCoroutine(coroutine);
                GetInstance().m_CoroutineList.Remove(coroutine);
            }
        }
        public static Coroutine SetTimer()
        {
            Coroutine coroutine = GetInstance().StartCoroutine(Timer());
            return coroutine;
        }
        private static IEnumerator Timer()
        {
            yield return null;
        }
    }
}
