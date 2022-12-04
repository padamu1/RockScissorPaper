using SimulFactory.System.Common.Bean;
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
            nameText.text = friendName;
            this.friendName = friendDto.FriendName;
        }
        public void YesButtonClicked()
        {
            C_FriendReceive.FriendReceiveC(true, friendName);
        }
        public void NoButtonClicked()
        {
            C_FriendReceive.FriendReceiveC(false, friendName);
        }
    }
}
