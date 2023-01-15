using SimulFactory.Game.Event;
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

        public void MatchClickedAction()
        {
            C_StartMatching.StartMatchingC((int)matchType);
        }
    }

}