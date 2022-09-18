using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.System.Common
{
    public class UserData : MonoSingleton<UserData>
    {
        public long UserNo { get; set; }
        public string UserName { get; set; }
    }
}
