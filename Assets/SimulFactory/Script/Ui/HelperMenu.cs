using SimulFactory.DataScript;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static SimulFactory.DataScript.HelperIconData;

namespace SimulFactory.Ui
{
    public class HelperMenu : MonoSingleton<HelperMenu>
    {
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text descText;
        private void Awake()
        {
            GetInstance();
            this.gameObject.SetActive(false);
        }
        public void SetHelperData(string key)
        {
            if(HelperIconData.HELPER_ICON_DATA.ContainsKey(key))
            {
                HelperData helperData = HELPER_ICON_DATA[key];

                string title = helperData.Title;
                string desc = helperData.Desc;
                SetTitle(title);
                SetDesc(desc);
                this.gameObject.SetActive(true);
            }
        }
        public void SetTitle(string title)
        {
            titleText.text = title;
        }
        public void SetDesc(string desc)
        {
            descText.text = desc;
        }
    }
}
