namespace SimulFactory.Context
{
    using SimulFactory.Context.Bean;
    using Slash.Unity.DataBind.Core.Data;
    using UnityEngine;

    public class UserInfoContext : Context
    {
        private readonly Property<string> UserNameProperty =
            new Property<string>();

        public string UserName
        {
            get
            {
                return UserNameProperty.Value;
            }
            set
            {
                UserNameProperty.Value = value;
            }
        }

        private readonly Property<string> UserGoldProperty =
            new Property<string>();

        public string UserGold
        {
            get
            {
                return UserGoldProperty.Value;
            }
            set
            {
                UserGoldProperty.Value = value;
            }
        }
        private readonly Property<Sprite> UserProfileProperty =
            new Property<Sprite>();

        public Sprite UserProfile
        {
            get
            {
                return UserProfileProperty.Value;
            }
            set
            {
                UserProfileProperty.Value = value;
            }
        }
    }
}
