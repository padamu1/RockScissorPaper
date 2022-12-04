using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class FriendRequestPopup : MonoSingleton<FriendRequestPopup>
    {
        public GameObject popup;
        private GameObject temp;

        public void GetPopup()
        {
            temp = Instantiate(popup);
        }

        public void DestroyPopup()
        {
            Destroy(temp);
        }
    }
}
