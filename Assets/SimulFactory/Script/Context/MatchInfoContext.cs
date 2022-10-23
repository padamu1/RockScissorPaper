using SimulFactory.Context.Bean;
using Slash.Unity.DataBind.Core.Data;
using UnityEngine;

namespace SimulFactory.Context
{
    public class MatchInfoContext : ContextBase
    {
        private readonly Property<string> UserRatingValue =
            new Property<string>();

        public string UserRating
        {
            get
            {
                return UserRatingValue.Value;
            }
            set
            {
                UserRatingValue.Value = value;
            }
        }

        private readonly Property<string> UserWinDefeatValue =
            new Property<string>();

        public string UserWinDefeat
        {
            get
            {
                return UserWinDefeatValue.Value;
            }
            set
            {
                UserWinDefeatValue.Value = value;
            }
        }
    }
}
