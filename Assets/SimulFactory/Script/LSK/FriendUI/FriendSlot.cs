using SimulFactory.Manager;
using SimulFactory.System.Common.Bean;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class FriendSlot : MonoBehaviour
    {
        [SerializeField] TMP_Text nameText;
        private string friendName;
        public void SetFriendDto(FriendDto friendDto)
        {
            this.friendName = friendDto.FriendName;
            nameText.text = friendName;
        }
        public void RemoveButtonClicked()
        {
            C_FriendRemove.FriendRemoveC(friendName);
            UiManager.GetInstance().GetFriendUiManager().RemoveFriendSlot(friendName);
        }
        internal static void GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}
