using System.Collections;
using System.Collections.Generic;

namespace SimulFactory.Context.Bean
{
    using Slash.Unity.DataBind.Core.Data;

    public class MasterContext : Context
    {
        private readonly Property<DataDictionary<string, ContextBase>> MasterContextValue =
            new Property<DataDictionary<string, ContextBase>>();

        public DataDictionary<string, ContextBase> Master
        {
            get
            {
                return MasterContextValue.Value;
            }
            set
            {
                MasterContextValue.Value = value;
            }
        }
        public void Reset()
        {
            foreach (KeyValuePair<string, ContextBase> data in MasterContextValue.Value)
            {
                data.Value.Reset();
            }
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
