using SimulFactory.Game.Event;
using SimulFactory.Manager;
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