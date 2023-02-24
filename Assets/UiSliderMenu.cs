using DG.Tweening;
using SimulFactory.Manager;
using SimulFactory.System.Common;
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

        // Child Member Field
        private RectTransform childRect;
        private float childSizeX = -1;           // 기본 값은 -1
        private float childSizeY = -1;           // 기본 값은 -1

        // Base Member Field
        protected Vector2[] SLIDER_POS_BASE_VALUE = new Vector2[]
        {
            new Vector2(1,0),
            new Vector2(1,0),
            new Vector2(0,1),
            new Vector2(0,1),
        };
        private void Start()
        {
            SetScrollRect();
            SetChildSize();

            // On Pointer Up 이벤트
            trigger = this.gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry beginDragEvent = new EventTrigger.Entry()
            {
                eventID = EventTriggerType.BeginDrag,
            };
            beginDragEvent.callback.AddListener(delegate { BeginDrag();});
            trigger.triggers.Add(beginDragEvent);

            // On Pointer Down 이벤트
            EventTrigger.Entry endDragEvent = new EventTrigger.Entry()
            {
                eventID = EventTriggerType.EndDrag,
            };
            endDragEvent.callback.AddListener(delegate { EndDrag(); });
            trigger.triggers.Add(endDragEvent);
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
        /// 마우스 클릭이 해제될 때 수행될 동작
        /// </summary>
        public void EndDrag()
        {
            Vector2 baseValue;
            float childBaseSize;
            float currentPos;
            switch(direction)
            {
                case SLIDER_DIRECTION.Right:
                    baseValue = SLIDER_POS_BASE_VALUE[0];
                    currentPos = content.anchoredPosition.x;
                    childBaseSize = childSizeX;
                    break;
                case SLIDER_DIRECTION.Left:
                    baseValue = SLIDER_POS_BASE_VALUE[1];
                    currentPos = content.anchoredPosition.x;
                    childBaseSize = childSizeX;
                    break;
                case SLIDER_DIRECTION.Up:
                    baseValue = SLIDER_POS_BASE_VALUE[2];
                    currentPos = content.anchoredPosition.y;
                    childBaseSize = childSizeY;
                    break;
                case SLIDER_DIRECTION.Down:
                    baseValue = SLIDER_POS_BASE_VALUE[3];
                    currentPos = content.anchoredPosition.y;
                    childBaseSize = childSizeY;
                    break;
                default:
                    Debug.LogError(" Direction Not Set ");
                    return;
            }
            baseValue *= (childBaseSize * Mathf.Round(currentPos / childBaseSize));

            content.DOAnchorPos(baseValue, 0.5f);
        }
        /// <summary>
        /// 마우스 클릭이 시작될 때 수행될 동작
        /// </summary>
        public void BeginDrag()
        {
            content.DOPause();
        }
    }
}