using SimulFactory.Context.Bean;
using Slash.Unity.DataBind.Core.Data;
using UnityEngine;

namespace SimulFactory.Context
{
    public class UserInfoContext : ContextBase
    {
        private readonly Property<string> UserNameValue =
            new Property<string>();

        public string UserName
        {
            get
            {
                return UserNameValue.Value;
            }
            set
            {
                UserNameValue.Value = value;
            }
        }

        private readonly Property<string> UserGoldValue =
            new Property<string>();

        public string UserGold
        {
            get
            {
                return UserGoldValue.Value;
            }
            set
            {
                UserGoldValue.Value = value;
            }
        }
        private readonly Property<Sprite> UserProfileValue =
            new Property<Sprite>();

        public Sprite UserProfile
        {
            get
            {
                return UserProfileValue.Value;
            }
            set
            {
                UserProfileValue.Value = value;
            }
        }
    }
}
