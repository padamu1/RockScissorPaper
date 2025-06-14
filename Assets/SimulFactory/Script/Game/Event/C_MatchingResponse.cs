using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class C_MatchingResponse
    {
        public static void MatchingResponseC(bool isAccept)
        {
            Dictionary<byte,object> dic = new Dictionary<byte,object>();
            dic.Add(0, isAccept);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.MatchingResponseC, dic);
        }
    }
}
