using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            string title = titleText.text;
            string desc = descText.text;
            SetTitle(title);
            SetDesc(desc);
            this.gameObject.SetActive(true);
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
