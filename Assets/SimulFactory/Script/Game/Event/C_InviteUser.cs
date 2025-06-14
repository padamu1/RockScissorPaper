using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class C_InviteUser
    {
        public static void InviteUserC(string userName)
        {
            Dictionary<byte, object> param = new Dictionary<byte, object>();
            param.Add(0, userName);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.InviteUserC, param);
        }
    }
}
