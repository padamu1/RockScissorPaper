using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class C_Ping
    {
        public static void PingC()
        {
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.PingC);
        }
    }
}
