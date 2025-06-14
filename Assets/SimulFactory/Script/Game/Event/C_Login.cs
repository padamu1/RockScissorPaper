using SimulFactory.Game.Event;
using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class C_Login
    {
        public static void LoginC(long userNo)
        {
            Dictionary<byte,object> dic = new Dictionary<byte,object>();
            dic[0] = userNo;
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.LoginC,dic);
        }
    }
}
