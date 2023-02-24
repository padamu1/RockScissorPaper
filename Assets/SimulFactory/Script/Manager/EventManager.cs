using UnityEngine;
using System.Collections.Generic;
using System;
using SimulFactory.System.Common;

namespace SimulFactory.Manager
{
    /// <summary>
    /// Event를 등록하고 관리하는 클래스.
    /// Singleton으로 관리
    /// </summary>
    public class EventManager : MonoSingleton<EventManager>
    {
        private Dictionary<Define.UNITY_EVENT, Action<Dictionary<string, object>>> EventList = new Dictionary<Define.UNITY_EVENT, Action<Dictionary<string, object>>>();

        /// <summary>
        /// EventListener의 Event 코드에 EventAction 추가
        /// </summary>
        /// <param name="Eventcode"></param>
        /// <param name="action"></param>
        public void StartListening(Define.UNITY_EVENT eventcode, Action<Dictionary<string, object>> eventAction)
        {
            if (EventList.ContainsKey(eventcode))
            {
                EventList[eventcode] += eventAction;
            }
            else
                EventList.Add(eventcode, eventAction);
        }

        /// <summary>
        /// EventListener의 Event 코드에서 EventAction 제거
        /// </summary>
        /// <param name="Eventcode"></param>
        /// <param name="action"></param>
        public void StopListening(Define.UNITY_EVENT eventcode, Action<Dictionary<string, object>> eventAction)
        {
            if (EventList.ContainsKey(eventcode))
                EventList[eventcode] -= eventAction;
            else
                Debug.Log("UNITY_EVENT does not exist");
        }
        /// <summary>
        /// Event 발생
        /// </summary>
        /// <param name="EventCode"></param>
        /// <param name="EventAction"></param>
        public void TriggerEvent(Define.UNITY_EVENT eventcode)
        {
            if (EventList.ContainsKey(eventcode))
            {
                EventList[eventcode]?.Invoke(null);
            }
            else
                Debug.Log("The EventList does not contain EVENT_CODE.");
        }

        /// <summary>
        /// Event 발생 + message
        /// </summary>
        /// <param name="EventCode"></param>
        /// <param name="EventAction"></param>
        public void TriggerEvent(Define.UNITY_EVENT eventcode, Dictionary<string, object> message = null)
        {
            if (EventList.ContainsKey(eventcode))
            {
                EventList[eventcode]?.Invoke(message);
            }
            else
                Debug.Log("The EventList does not contain EVENT_CODE.");
        }
    }
}