using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class C_SetProfile
    {
        public static void SetProflieC(string userProfile)
        {
            Dictionary<byte, object> param = new Dictionary<byte, object>();
            param.Add(0, userProfile);
            SocketManager.GetInstance().SendPacket((byte)Define.EVENT_CODE.SetProfileC, param);
        }
    }
}
