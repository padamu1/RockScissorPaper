using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.DataScript
{
    public class HelperIconData
    {
        public class HelperData
        {
            public string Desc;
            public string Title;
        }
        public static Dictionary<string, HelperData> HELPER_ICON_DATA = new Dictionary<string, HelperData>()
        {
            {"NormalGameMode",new HelperData(){
                Title = "노말 모드",
                Desc = "1:1로 승부를 겨루세요.",
            }},
            {"MultiGameMode",new HelperData(){
                Title = "멀티 모드(6명)",
                Desc = "최대 5명의 플레이어와 대전하세요.",
            }},
        };
    }
}
