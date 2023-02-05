
using SimulFactory.System.Common;
using System.Collections.Generic;

namespace SimulFactory.Game.Event
{
    public class S_LoadProfile
    {
        public static void LoadProfileS(Dictionary<byte, object> param)
        {
            UserData.GetInstance().SetMyProfile((string)param[1]); // 유저 데이터
        }
    }
}

