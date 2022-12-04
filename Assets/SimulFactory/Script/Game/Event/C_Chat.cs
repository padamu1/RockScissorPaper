using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class C_Chat
    {
        public static void ChatC(long chatType, string chatText, string targetName = "")
        {
            Dictionary<byte, object> param = new Dictionary<byte, object>();
            param.Add(0, chatType);
            param.Add(1, chatText);
            param.Add(2, targetName);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.ChatC, param);
        }
    }
}
