using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class C_FriendReceive
    {
        public static void FriendReceiveC(bool isReceived, string friendName)
        {
            Dictionary<byte, object> dic = new Dictionary<byte, object>();
            dic.Add(0, isReceived);
            dic.Add(1, friendName);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.FriendReceiveC, dic);
        }
    }
}
