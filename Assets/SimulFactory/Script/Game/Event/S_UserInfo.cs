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
            UserData.GetInstance().SetUserName((string)param[0]); // 유저 닉네임
            UserData.GetInstance().UpdateUserInfoContext();
            UserData.GetInstance().GetPvpInfo().Rating = (int)param[1];
            UserData.GetInstance().GetPvpInfo().WinCount = (int)param[2];
            UserData.GetInstance().GetPvpInfo().DefeatCount = (int)param[3];
            UserData.GetInstance().GetMultiPvpInfo().WinCount = (int)param[4];
            UserData.GetInstance().GetMultiPvpInfo().DefeatCount = (int)param[5];
            UserData.GetInstance().UpdateMatchInfoContext();
            UserData.GetInstance().UpdateMultiMatchInfoContext();
        }
    }
}
