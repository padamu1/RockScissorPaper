using System.Collections;
using System.Collections.Generic;

namespace SimulFactory.Context.Bean
{
    using Slash.Unity.DataBind.Core.Data;

    public class MasterContext : Context
    {
        private readonly Property<DataDictionary<string, Context>> MasterProperty =
            new Property<DataDictionary<string, Context>>();

        public DataDictionary<string, Context> Master
        {
            get
            {
                return MasterProperty.Value;
            }
            set
            {
                MasterProperty.Value = value;
            }
        }
        public void Reset()
        {
            Master.Clear();
        }
        public MasterContext()
        {
            MasterProperty.Value = new DataDictionary<string, Context>();
        }
    }

    public class ContextBase : Context
    {
        public virtual void Reset()
        {
            // ¸®¼Â 
        }
    }
}
