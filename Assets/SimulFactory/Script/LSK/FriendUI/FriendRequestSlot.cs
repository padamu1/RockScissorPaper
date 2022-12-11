using SimulFactory.System.Common.Bean;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class FriendRequestSlot : MonoBehaviour
    {
        [SerializeField] TMP_Text nameText;
        private string friendName;
        public void SetFriendRequestDto(FriendRequestDto friendDto)
        {
            this.friendName = friendDto.FriendName;
            nameText.text = friendName;
        }
        public void YesButtonClicked()
        {
            C_FriendReceive.FriendReceiveC(true, friendName);
            FriendUIManager.GetInstance().RemoveFriendRequesSlot(friendName);
        }
        public void NoButtonClicked()
        {
            C_FriendReceive.FriendReceiveC(false, friendName);
            FriendUIManager.GetInstance().RemoveFriendRequesSlot(friendName);
        }

        internal static void GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}
