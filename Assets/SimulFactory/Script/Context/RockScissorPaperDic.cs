using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Context
{
    using SimulFactory.Context.Bean;
    using Slash.Unity.DataBind.Core.Data;
    using UnityEngine;

    public class RockScissorPaperDic : ContextBase
    {
        private readonly Property<DataDictionary<string, Context>> RockScissorPaperDicValue =
            new Property<DataDictionary<string, Context>>();

        public DataDictionary<string, Context> RockScissorPaper
        {
            get
            {
                return RockScissorPaperDicValue.Value;
            }
            set
            {
                RockScissorPaperDicValue.Value = value;
            }
        }
        public override void Reset()
        {
            RockScissorPaper.Clear();
        }
        public RockScissorPaperDic()
        {
            RockScissorPaperDicValue.Value = new DataDictionary<string, Context>();
        }
    }
    public class RockScissorPaper : Context
    {
        private readonly Property<Action> SlotButtonActionValue =
            new Property<Action>();

        public Action SlotButtonAction
        {
            get
            {
                return SlotButtonActionValue.Value;
            }
            set
            {
                SlotButtonActionValue.Value = value;
            }
        }

        private readonly Property<string> SlotButtonTextValue =
            new Property<string>();

        public string SlotButtonText
        {
            get
            {
                return SlotButtonTextValue.Value;
            }
            set
            {
                SlotButtonTextValue.Value = value;
            }
        }

        private readonly Property<Sprite> SlotButtonImgValue =
            new Property<Sprite>();

        public Sprite SlotButtonImg
        {
            get
            {
                return SlotButtonImgValue.Value;
            }
            set
            {
                SlotButtonImgValue.Value = value;
            }
        }
    }
}
