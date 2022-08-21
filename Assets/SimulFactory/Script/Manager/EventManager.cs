using UnityEngine;
using System.Collections.Generic;
using System;
namespace SimulFactory.Manager
{
    /// <summary>
    /// Event를 등록하고 관리하는 클래스.
    /// Singleton으로 관리
    /// </summary>
    public class EventManager : MonoSingleton<EventManager>
    {
        private Dictionary<byte, Action<Dictionary<string, object>>> EventList = new Dictionary<byte, Action<Dictionary<string, object>>>();

        /// <summary>
        /// EventListener의 Event 코드에 EventAction 추가
        /// </summary>
        /// <param name="Eventcode"></param>
        /// <param name="action"></param>
        public void StartListening(byte Eventcode, Action<Dictionary<string, object>> EventAction)
        {
            if (EventList.ContainsKey(Eventcode))
            {
                EventList[Eventcode] += EventAction;
            }
            else
                EventList.Add(Eventcode, EventAction);
        }

        /// <summary>
        /// EventListener의 Event 코드에서 EventAction 제거
        /// </summary>
        /// <param name="Eventcode"></param>
        /// <param name="action"></param>
        public void StopListening(byte Eventcode, Action<Dictionary<string, object>> EventAction)
        {
            if (EventList.ContainsKey(Eventcode))
                EventList[Eventcode] -= EventAction;
            else
                Debug.Log("EventCode does not exist");
        }
        /// <summary>
        /// Event 발생
        /// </summary>
        /// <param name="EventCode"></param>
        /// <param name="EventAction"></param>
        public void TriggerEvent(byte EventCode)
        {
            if (EventList.ContainsKey(EventCode))
            {
                EventList[EventCode]?.Invoke(null);
            }
            else
                Debug.Log("The EventList does not contain EventCode.");
        }

        /// <summary>
        /// Event 발생 + message
        /// </summary>
        /// <param name="EventCode"></param>
        /// <param name="EventAction"></param>
        public void TriggerEvent(byte EventCode, Dictionary<string, object> message = null)
        {
            if (EventList.ContainsKey(EventCode))
            {
                EventList[EventCode]?.Invoke(message);
            }
            else
                Debug.Log("The EventList does not contain EventCode.");
        }
    }
}