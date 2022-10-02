using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimulFactory.System.Common;
namespace SimulFactory.Manager
{    
    public class WorldManager : MonoSingleton<WorldManager>
    {
        public void Start()
        {
            ObjectPoolManager.GetInstance().SetPool(Resources.Load<GameObject>("Ui/Popup/MainPopup"),Define.MAINPOPUP_SET_COUNT);
            ObjectPoolManager.GetInstance().SetPool(Resources.Load<GameObject>("Ui/Popup/ToastPopup"),Define.TOASTPOPUP_SET_COUNT);
        }
    }
}
