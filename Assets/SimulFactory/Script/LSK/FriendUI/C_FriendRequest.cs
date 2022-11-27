using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimulFactory.Game.Event
{
    public class C_FriendRequest
    {
        public static void FriendRequestC(string userName)
        {
            Dictionary<byte, object> dic = new Dictionary<byte, object>();
            dic.Add(0, userName);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.FriendRequestC, dic);
        }
    }
}
