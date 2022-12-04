using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.Game.Event
{
    public class C_Chat
    {
        public static void ChatC(bool isReceived)
        {
            Dictionary<byte, object> dic = new Dictionary<byte, object>();
            dic.Add(0, isReceived);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.FriendReceiveC, dic);
        }
    }
}
