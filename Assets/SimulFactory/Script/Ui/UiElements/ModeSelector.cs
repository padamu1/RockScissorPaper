using SimulFactory.Game.Event;
using SimulFactory.Manager;
using SimulFactory.Script.Util;
using SimulFactory.System.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimulFactory.Ui.UiElements
{
    public class ModeSelector : MonoBehaviour
    {
        [SerializeField] Define.MATCH_TYPE matchType;
        [SerializeField] private GameObject blockObject;
        private RectTransform thisRect;
        private void Awake()
        {
            thisRect = this.gameObject.GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            // ViewPort의 Rect Transform의 width를 불러와 설정
            thisRect.sizeDelta = new Vector2(this.transform.parent.parent.GetComponent<RectTransform>().rect.width,thisRect.rect.height);    
        }
        private void HideAction()
        {
            blockObject.gameObject.SetActive(false);
        }
        private void ShowAction()
        {
            blockObject.gameObject.SetActive(true);
        }
        public void MatchClickedAction()
        {
            BattleManager.GetInstance().SetMatchingShowAction(ShowAction);
            BattleManager.GetInstance().SetMatchingHideAction(HideAction);
            C_StartMatching.StartMatchingC((int)matchType);
        }
    }

}