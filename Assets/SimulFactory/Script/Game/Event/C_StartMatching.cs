using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class C_StartMatching
    {
        public static void StartMatchingC(int type = 1)
        {
            Dictionary<byte, object> dic = new Dictionary<byte, object>();
            dic.Add(0, type);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.StartMatchingC, dic);
        }
    }
}
