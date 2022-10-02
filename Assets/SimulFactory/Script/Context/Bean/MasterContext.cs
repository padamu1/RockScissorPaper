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
            Master.Clear();
        }
        public MasterContext()
        {
            MasterContextValue.Value = new DataDictionary<string, ContextBase>();
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
