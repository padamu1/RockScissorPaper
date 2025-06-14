using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimulFactory.Game.Event
{
    public class C_UserBattleButtonClicked
    {
        public static void UserBattleButtonClickedC(int buttonNo)
        {
            Dictionary<byte, object> dic = new Dictionary<byte, object>();
            dic.Add(0, buttonNo);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.UserBattleButtonClickedC, dic);
        }
    }
}
