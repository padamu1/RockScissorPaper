using SimulFactory.System.Common.Bean;
using SimulFactory.System.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SimulFactory.Game.Event
{
    public class FriendUIManager : MonoSingleton<FriendUIManager>
    {
        public GameObject friendSlot;
        public GameObject parentObject;

        Dictionary<string, GameObject> friendSlotDic;

        private void Awake()
        {
            friendSlotDic = new Dictionary<string, GameObject>();
        }

        public void AddFriend(FriendDto friendDto)
        {
            GameObject obj = Instantiate(friendSlot, parentObject.transform, false);
            friendSlotDic.Add(friendDto.FriendName, obj);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = friendDto.FriendName;
        }
        public void AddFriend(FriendRequestDto friendDto)
        {
            GameObject obj = Instantiate(friendSlot, parentObject.transform, false);
            friendSlotDic.Add(friendDto.FriendName, obj);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = friendDto.FriendName;
        }

        public void SetFriendSlot()
        {
            if (UserData.GetInstance().GetFriends() != null)
            {
                foreach (KeyValuePair<string, FriendDto> data in UserData.GetInstance().GetFriends())
                {
                    AddFriend(data.Value);
                }
            }
        }

        public void SetFriendRequestSlot(string friendName)
        {
            AddFriend(UserData.GetInstance().GetFriendRequestDto(friendName));
        }
    }
}
