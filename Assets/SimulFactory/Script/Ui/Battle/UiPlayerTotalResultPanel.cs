using SimulFactory.Manager;
using SimulFactory.Ui.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimulFactory.Ui.Battle
{
    public class UiPlayerTotalResultPanel : MonoBehaviour, IRegistPanel
    {
        [SerializeField] private UiPlayerTotalResultSlot[] uiPlayerTotalResultSlots;
        private Dictionary<string, UiPlayerTotalResultSlot> userTotalResultDic;
        private void OnEnable()
        {
            RegistPanelThisPanel();
            SetUserCount();
        }
        private void SetUserCount()
        {
            userTotalResultDic = new Dictionary<string, UiPlayerTotalResultSlot>();
            for (int count = 0; count < uiPlayerTotalResultSlots.Length; count++)
            {
                uiPlayerTotalResultSlots[count].gameObject.SetActive(true);
                uiPlayerTotalResultSlots[count].SetName(count.ToString());
                userTotalResultDic.Add(count.ToString(), uiPlayerTotalResultSlots[count]);
            }
        }
        
        public void RegistPanelThisPanel()
        {
            UiManager.GetInstance().RegistUiPlayerTotalResultPanel(this);
        }
        public void SetUserWin(string name)
        {
            if(userTotalResultDic.ContainsKey(name))
            {
                userTotalResultDic[name].IncreaseWinCount();
            }
        }
    }
}
