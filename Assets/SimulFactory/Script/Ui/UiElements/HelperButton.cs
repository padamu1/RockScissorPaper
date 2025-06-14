using SimulFactory.System.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimulFactory.Ui.UiElements
{
    public class HelperButton : MonoBehaviour
    {
        [SerializeField] private Define.HELP_MENU helpMenu;
        public void ShowHelperMenu()
        {
            HelperMenu.GetInstance().SetHelperData(helpMenu.ToString());
        }
    }

}