using SimulFactory.System.Common;
using SimulFactory.Ui.Popup;
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
        private int _topStartOrder;
        private int _topEndOrder;
        private int _order;
        private PopupInfo _popupInfo;
        public PopupManager()
        {
            _popupDic = new Dictionary<int, PopupBase>();
            _topStartOrder = Define.POPUP_TOP_START_ORDER;
            _topEndOrder = Define.POPUP_TOP_END_ORDER;
            _order = _topStartOrder;
            _popupInfo = new PopupInfo();
        }
        public class PopupInfo
        {
            public Define.POPUP_TYPE Type;
            public string Title;
            public string Description;
            public string YesButtonText;
            public string NoButtonText;
            public Action YesButtonAction;
            public Action NoButtonAction;
            public bool Top;
            public bool Block;
            public string WarningText;
            public Action<string> InputAction;
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
                InputAction = null;
                WarningText = String.Empty;
            }
        }
        public virtual void CreatePopup(PopupInfo popupInfo)
        {
            switch (popupInfo.Type)
            {
                case Define.POPUP_TYPE.InputPopup:
                case Define.POPUP_TYPE.YesNoPopup:
                    {
                        GameObject obj = ObjectPoolManager.GetInstance().SpawnFromPool(Define.UNIT_PREFAB.MainPopup.ToString());
                        if (popupInfo.Top)
                        {
                            obj.GetComponent<Canvas>().sortingOrder = GetOrder();
                        }
                        MainPopup mainPopup = obj.GetComponent<MainPopup>();
                        mainPopup.SetInfo(popupInfo);
                    }
                    break;
                case Define.POPUP_TYPE.ToastPopup:
                    {
                        GameObject obj = ObjectPoolManager.GetInstance().SpawnFromPool(Define.UNIT_PREFAB.ToastPopup.ToString());
                        if (popupInfo.Top)
                        {
                            obj.GetComponent<Canvas>().sortingOrder = GetOrder();
                        }
                        ToastPopup mainPopup = obj.GetComponent<ToastPopup>();
                        mainPopup.SetInfo(popupInfo);
                    }
                    break;

            }

        }
        private int GetOrder()
        {
            if(_order > _topEndOrder)
            {
                _order = _topStartOrder;
            }
            return _order++;
        }
        public PopupInfo GetPopupInfo()
        {
            _popupInfo.Reset();
            return _popupInfo;
        }
    }
}
