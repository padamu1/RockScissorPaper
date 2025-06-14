namespace SimulFactory.Context
{
    using SimulFactory.Context.Bean;
    using Slash.Unity.DataBind.Core.Data;
    using UnityEngine;

    public class MatchInfoContext : Context
    {
        private readonly Property<string> UserRatingProperty =
            new Property<string>();

        public string UserRating
        {
            get
            {
                return UserRatingProperty.Value;
            }
            set
            {
                UserRatingProperty.Value = value;
            }
        }

        private readonly Property<string> UserWinDefeatProperty =
            new Property<string>();

        public string UserWinDefeat
        {
            get
            {
                return UserWinDefeatProperty.Value;
            }
            set
            {
                UserWinDefeatProperty.Value = value;
            }
        }
    }
}
