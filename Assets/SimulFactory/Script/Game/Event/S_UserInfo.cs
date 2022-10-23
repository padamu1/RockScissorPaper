using SimulFactory.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Game.Event
{
    public class S_UserInfo
    {
        public static void UserInfoS(Dictionary<byte,object> param)
        {
            UserData.GetInstance().UserName = (string)param[0]; // 유저 닉네임
            UserData.GetInstance().UpdateUserInfoContext();
            UserData.GetInstance().pvpInfo.Rating = Convert.ToInt32(param[1]);
            UserData.GetInstance().pvpInfo.WinCount = Convert.ToInt32(param[2]);
            UserData.GetInstance().pvpInfo.DefeatCount = Convert.ToInt32(param[3]);
            UserData.GetInstance().UpdateMatchInfoContext();
        }
    }
}
