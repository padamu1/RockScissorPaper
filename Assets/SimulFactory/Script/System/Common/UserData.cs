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
        public bool IsFirstActive = true;
        private StringBuilder sb;
        // Context 변수들
        private UserInfoContext _userInfoContext;
        private MatchInfoContext _matchInfoContext;
        private MatchInfoContext _multiMatchInfoContext;

        // 유저 정보가 담긴 변수들
        public long UserNo { get; set; }
        private string userName;
        private PvpInfo pvpInfo;
        private PvpInfo pvpInfoMulti;

        //친구목록
        private Dictionary<string, FriendDto> friends;
        private Dictionary<string, FriendRequestDto> friendRequests;
        private void Awake()
        {
            sb = new StringBuilder();
        }
        public void ResetUserData()
        {
            friends = new Dictionary<string, FriendDto>();
            friendRequests = new Dictionary<string, FriendRequestDto>();
            pvpInfo = new PvpInfo();
            pvpInfoMulti = new PvpInfo();
            InitUserDataContext();
        }
        //친구목록 받아오기
        public void AddFriend(FriendDto data)
        {
            if (friends.ContainsKey(data.FriendName))
            {
                return;
            }

            friends.Add(data.FriendName, data);
        }

        public Dictionary<string, FriendDto> GetFriends()
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

        public void RemoveFriend(string friendName)
        {
            if (friends.ContainsKey(friendName))
            {
                friends.Remove(friendName);
            }
        }
        public FriendRequestDto GetFriendRequestDto(string friendName)
        {
            if (friendRequests.ContainsKey(friendName))
            {
                return friendRequests[friendName];
            }
            return null;
        }    
        public void AddFriendRequestDto(FriendRequestDto friendRequestDto)
        {
            if (friendRequests.ContainsKey(friendRequestDto.FriendName))
            {
                return;
            }
            friendRequests.Add(friendRequestDto.FriendName, friendRequestDto);
        }
        public Dictionary<string, FriendRequestDto> GetFriendReuqests()
        {
            return friendRequests;
        }
        public void RemoveFriendRequest(string friendName)
        {
            if (friendRequests.ContainsKey(friendName))
            {
                friendRequests.Remove(friendName);
            }
        }
        public void SetUserName(string userName)
        {
            this.userName = userName;
            _userInfoContext.SetValue("UserName",userName);

        }
        public string GetUserName()
        {
            return userName;
        }
        public PvpInfo GetPvpInfo()
        {
            return pvpInfo;
        }
        public PvpInfo GetMultiPvpInfo()
        {
            return pvpInfoMulti;
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

            _multiMatchInfoContext = new MatchInfoContext();
            UpdateMultiMatchInfoContext();
            masterContext.Master.Add(Define.CONTEXT_LIST.MultiMatchInfo.ToString(), _matchInfoContext);
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
                winRate = (pvpInfo.WinCount / (pvpInfo.DefeatCount + pvpInfo.WinCount)) * 100f;
            }
            sb.AppendFormat("{0:D} %", winRate.ToString());
            _matchInfoContext.SetValue("UserWinDefeat", sb.ToString());
        }
        public void UpdateMultiMatchInfoContext()
        {
            _multiMatchInfoContext.SetValue("UserRating", string.Format("{0} pt", pvpInfoMulti.Rating));

            sb.Clear();
            sb.AppendFormat("{0} 승 / {1} 패\n", pvpInfoMulti.WinCount, pvpInfoMulti.DefeatCount);
            float winRate = 0;
            if(pvpInfoMulti.DefeatCount == 0)
            {
                winRate = 100;
            }
            else
            {
                winRate = (pvpInfoMulti.WinCount / ( pvpInfoMulti.DefeatCount + pvpInfoMulti.WinCount)) * 100f;
            }
            sb.AppendFormat("{0:D} %", winRate.ToString());
            _multiMatchInfoContext.SetValue("UserWinDefeat", sb.ToString());
        }

    }
}
