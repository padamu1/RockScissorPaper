using SimulFactory.Context;
using SimulFactory.Context.Bean;
using SimulFactory.Manager;
using SimulFactory.System.Common.Bean;
using System.Collections.Generic;
using System.Text;

namespace SimulFactory.System.Common
{
    public class UserData : MonoSingleton<UserData>
    {
        private StringBuilder sb;
        // Context 변수들
        private UserInfoContext _userInfoContext;
        private MatchInfoContext _matchInfoContext;

        // 유저 정보가 담긴 변수들
        public long UserNo { get; set; }
        private string userName;
        private PvpInfo pvpInfo;

        //친구목록
        private Dictionary<string, FriendDto> friends;

        //친구목록 받아오기
        public void SetUserFriendList(FriendDto data)
        {
            if (friends.ContainsKey(data.FriendName))
            {
                return;
            }

            friends.Add(data.FriendName, data);
        }

        public Dictionary<string, FriendDto> getFriends()
        {
            return friends;
        }
        public FriendDto GetFriendDto(string friendName)
        {
            if(friends.ContainsKey(friendName))
            {
                return friends[friendName];
            }
            return null;
        }


        private void Awake()
        {
            sb = new StringBuilder();
        }
        public void SetUserName(string userName)
        {
            this.userName = userName;
        }
        public string GetUserName()
        {
            return userName;
        }
        public PvpInfo GetPvpInfo()
        {
            return pvpInfo;
        }
        public void ResetUserData()
        {
            pvpInfo = new PvpInfo();
            InitUserDataContext();
        }
        /// <summary>
        /// 컨텍스트 초기화
        /// </summary>
        public void InitUserDataContext()
        {
            MasterContext masterContext = Managers.GetInstance().GetMasterContext();
            
            _userInfoContext = new UserInfoContext();
            UpdateUserInfoContext();
            _userInfoContext.UserName = "asdf";
            masterContext.Master.Add(Define.CONTEXT_LIST.UserInfo.ToString(), _userInfoContext);
            
            _matchInfoContext = new MatchInfoContext();
            UpdateMatchInfoContext();
            masterContext.Master.Add(Define.CONTEXT_LIST.MatchInfo.ToString(), _matchInfoContext);
        }
        /// <summary>
        /// 유저 정보 컨텍스트 업데이트
        /// </summary>
        public void UpdateUserInfoContext()
        {
            _userInfoContext.SetValue("UserName",userName);
        }
        public void UpdateMatchInfoContext()
        {
            _matchInfoContext.SetValue("UserRating", string.Format("{0} pt", pvpInfo.Rating));

            sb.Clear();
            sb.AppendFormat("{0} 승 / {1} 패\n", pvpInfo.WinCount, pvpInfo.DefeatCount);
            float winRate = 0;
            if(pvpInfo.DefeatCount == 0)
            {
                winRate = 100;
            }
            else
            {
                winRate = (float)pvpInfo.WinCount / pvpInfo.DefeatCount;
            }
            sb.AppendFormat("{0:D} %", winRate.ToString());
            _matchInfoContext.SetValue("UserWinDefeat", sb.ToString());
        }

    }
}
