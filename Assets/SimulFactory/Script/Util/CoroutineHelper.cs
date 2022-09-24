using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.Script.Util
{
    public class CoroutineHelper : MonoSingleton<CoroutineHelper>
    {
        private Dictionary<float, WaitForSeconds> m_waitForSecondDic;
        private List<Coroutine> m_logoStopCoroutineList;
        private List<Coroutine> m_coroutineList;
        private void Awake()
        {
            m_waitForSecondDic = new Dictionary<float, WaitForSeconds>();
            m_logoStopCoroutineList = new List<Coroutine>();
            m_coroutineList = new List<Coroutine>();
        }
        /// <summary>
        /// Dictionary에 생성된 혹은 생성 후 WaitForSeconds 반환
        /// </summary>
        /// <param name="waitForSecond"></param>
        /// <returns>WaitForSeconds</returns>
        public static WaitForSeconds GetWaitForSeconds(float waitForSecond)
        {
            if(!GetInstance().m_waitForSecondDic.ContainsKey(waitForSecond))
            {
                GetInstance().m_waitForSecondDic.Add(waitForSecond, new WaitForSeconds(waitForSecond));
            }

            return GetInstance().m_waitForSecondDic[waitForSecond];
        }
        /// <summary>
        /// 로고로 돌아갈 때 멈추는 코루틴 설정
        /// </summary>
        /// <param name="enumerator"></param>
        /// <returns>코루틴</returns>
        public static Coroutine StartLogoStopCoroutine(IEnumerator enumerator)
        {
            Coroutine coroutine = GetInstance().StartCoroutine(enumerator);
            GetInstance().m_logoStopCoroutineList.Add(coroutine);
            return coroutine;
        }
        /// <summary>
        /// 로고로 돌아갈 때 멈추는 코루틴 중 하나 해제
        /// </summary>
        /// <param name="coroutine"></param>
        public static void StopLogoStopCoroutine(Coroutine coroutine)
        {
            if(GetInstance().m_logoStopCoroutineList.Contains(coroutine))
            {
                GetInstance().StopCoroutine(coroutine);
                GetInstance().m_logoStopCoroutineList.Remove(coroutine);
            }
        }
        /// <summary>
        /// 모든 코루틴 해제
        /// </summary>
        public static void StopAllLogoStopCoroutine()
        {
            while(GetInstance().m_logoStopCoroutineList.Count > 0)
            {
                StopLogoStopCoroutine(GetInstance().m_logoStopCoroutineList[0]);
            }
        }
        /// <summary>
        /// 타이머 설정
        /// </summary>
        /// <returns></returns>
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
