using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SimulFactory.Ui
{
    public enum SLIDER_DIRECTION
    { 
        None,
        Right,
        Left,
        Up,
        Down,
    }
    public class UiSliderMenu : MonoBehaviour
    {
        // Serialized Field
        public SLIDER_DIRECTION direction;

        // Base Component
        private ScrollRect scrollRect;
        private RectTransform content;
        private EventTrigger trigger;
        // Parent Member Field
        private Transform parentTransform;
        private float parentSizeX = -1;
        private float parentSizeY = -1;

        // Child Member Field
        private RectTransform childRect;
        private float childSizeX = -1;           // 기본 값은 -1
        private float childSizeY = -1;           // 기본 값은 -1

        private void Awake()
        {
            SetScrollRect();
            SetParentSize();
            SetChildSize();
        }
        private void Start()
        {
            trigger = this.gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry pointerUpEvent = new EventTrigger.Entry()
            {
                eventID = EventTriggerType.PointerUp,
            };
            pointerUpEvent.callback.AddListener(delegate { OnPointerUp();});
            
            trigger.triggers.Add(pointerUpEvent);
        }
        /// <summary>
        /// ScrollRect 초기화
        /// </summary>
        private void SetScrollRect()
        {
            scrollRect = gameObject.GetComponent<ScrollRect>();
            content = scrollRect.content;
        }
        /// <summary>
        /// Parent 사이즈 초기화
        /// </summary>
        private void SetParentSize()
        {
            parentSizeX = content.rect.width;
            parentSizeY = content.rect.height;
            parentTransform = content.transform;
        }
        /// <summary>
        /// Child 사이즈 초기화
        /// </summary>
        private void SetChildSize()
        {
            childRect = content.GetChild(0)?.GetComponent<RectTransform>();
            if(childRect == null)
            {
                Debug.LogError("콘텐츠 내부에 오브젝트가 없음 확인 필요!");
                return;
            }
            childSizeX = childRect.rect.width;
            childSizeY = childRect.rect.height;
        }
        /// <summary>
        /// Pointer가 올라올 때 수행될 동작
        /// </summary>
        public void OnPointerUp()
        {
            switch(direction)
            {
                case SLIDER_DIRECTION.Right:

                    break;
                case SLIDER_DIRECTION.Left:

                    break;
                case SLIDER_DIRECTION.Up:

                    break;
                case SLIDER_DIRECTION.Down:

                    break;
                default:
                    Debug.LogError(" Direction Not Set ");
                    break;
            }
        }
    }
}