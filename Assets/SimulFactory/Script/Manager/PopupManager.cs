using SimulFactory.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Manager
{
    public class PopupManager : MonoSingleton<PopupManager>
    {
        private Dictionary<int, PopupBase> _popupDic;
        public PopupManager()
        {
            _popupDic = new Dictionary<int, PopupBase>();
        }
        public class PopupInfo
        {
            public string Title;
            public string Description;
            public string YesButtonText;
            public string NoButtonText;
            public Action YesButtonAction;
            public Action NoButtonAction;
            public bool Top;
            public bool Block;
            public void Reset()
            {
                Title = "";
                Description = "";
                YesButtonText = "";
                NoButtonText = "";
                YesButtonAction = null;
                NoButtonAction = null;
                Top = false;
                Block = false;
            }
        }
        public virtual void CreatePopup(PopupInfo popupInfo)
        {
            GameObject obj = ObjectPoolManager.GetInstance().SpawnFromPool("YesNoPopup");
            obj.name = popupInfo.Title;
        }
    }
}
