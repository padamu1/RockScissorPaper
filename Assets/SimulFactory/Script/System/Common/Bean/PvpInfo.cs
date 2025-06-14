using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.System.Common.Bean
{
    public class PvpInfo
    {
        public int Rating { get; set; }
        public int WinCount { get; set; }
        public int DefeatCount { get; set; }
    }

    public class FriendRequestDto
    {
        public string FriendName { get; set; }
        public long FriendNo { get; set; }
    }

    public class FriendDto
    {
        public string FriendName { get; set; }
        public long ConnectionTime { get; set; }
        public long FriendNo { get; set; }
    }
}
