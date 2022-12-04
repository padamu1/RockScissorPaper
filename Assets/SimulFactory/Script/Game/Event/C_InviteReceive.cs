using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class C_InviteReceive
    {
        public static void InviteReceiveC(bool result, long inviteUserNo)
        {
            Dictionary<byte,object> param = new Dictionary<byte,object>();
            param.Add(0, result);
            param.Add(1, inviteUserNo);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.InviteReceiveC, param);
        }
    }
}
