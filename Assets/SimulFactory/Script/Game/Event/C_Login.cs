using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game
{
    public class C_Login
    {
        public static void LoginC(string userId, string userName)
        {
            Dictionary<byte,object> dic = new Dictionary<byte,object>();
            dic[0] = userId;
            dic[1] = userName;
            dic[2] = 1000;
            dic[3] = 0;
            dic[4] = 0;
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.LoginC,dic);
        }
    }
}
