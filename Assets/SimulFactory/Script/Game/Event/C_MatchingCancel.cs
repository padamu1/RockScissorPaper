using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class C_MatchingCancel
    {
        public static void MatchingCancelC()
        {
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.MatchingCancelC);
        }
    }
}
