using SimulFactory.System.Common.Bean;
using SimulFactory.System.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimulFactory.Manager;

namespace SimulFactory.Game.Event
{
    public class FriendUIManager : MonoBehaviour
    {
        public GameObject friendSlot;
        public GameObject friendRequestSlot;
        public GameObject parentObject;
        public GameObject friendRequestParentObject;

        Dictionary<string, GameObject> friendSlotDic;
        Dictionary<string, GameObject> friendRequestSlotDic;

        public void Init()
        {
            friendSlotDic = new Dictionary<string, GameObject>();
            friendRequestSlotDic = new Dictionary<string, GameObject>();
        }

        public void AddFriend(FriendDto friendDto)
        {
            GameObject obj = Instantiate(friendSlot, parentObject.transform, false);
            friendSlotDic.Add(friendDto.FriendName, obj);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = friendDto.FriendName;
        }
        public void AddFriend(FriendRequestDto friendDto)
        {
            GameObject obj = Instantiate(friendRequestSlot, friendRequestParentObject.transform, false);
            friendRequestSlotDic.Add(friendDto.FriendName, obj);
            obj.GetComponent<FriendRequestSlot>().SetFriendRequestDto(friendDto);
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

        public void RemoveFriendSlot(string friendName)
        {
            if (friendSlotDic.TryGetValue(friendName, out GameObject obj))
            {
                Destroy(obj);
            }
        }

        public void RemoveFriendRequestSlot(string friendName)
        {
            if (friendRequestSlotDic.TryGetValue(friendName, out GameObject obj))
            {
                Destroy(obj);
            }
        }

        public void SetFriendRequestSlot(string friendName)
        {
            AddFriend(UserData.GetInstance().GetFriendRequestDto(friendName));
        }
        public void AddFriendButtonClicked()
        {
            PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
            popupInfo.Type = Define.POPUP_TYPE.InputPopup;
            popupInfo.Title = "친구 요청";
            popupInfo.NoButtonText = "취소";
            popupInfo.YesButtonText = "요청";
            popupInfo.InputAction = C_FriendRequest.FriendRequestC;
            popupInfo.Top = true;
            popupInfo.Block = true;
            PopupManager.GetInstance().CreatePopup(popupInfo);
        }
        // 친구요청 왔을때 수락버튼 클릭
        public void FriendReceiveButtonClicked(bool isReceived, string friendName)
        {
            C_FriendReceive.FriendReceiveC(isReceived, friendName);
        }

        // 친구 삭제버튼 클릭
        public void FriendRemoveButtonClicked(string userName)
        {
            C_FriendRemove.FriendRemoveC(userName);
        }
    }
}
