using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimulFactory.Game.Event
{
    public class C_UserBattleButtonClicked
    {
        public static void UserBattleButtonClicked(string buttonName)
        {
            Dictionary<byte, object> dic = new Dictionary<byte, object>();
            dic.Add(0, buttonName);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.UserBattleButtonClicked, dic);
        }
    }
}
