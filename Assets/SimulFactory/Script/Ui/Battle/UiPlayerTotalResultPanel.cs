using SimulFactory.Manager;
using SimulFactory.System.Common;
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

            uiPlayerTotalResultSlots[0].gameObject.SetActive(true);
            uiPlayerTotalResultSlots[0].SetName(UserData.GetInstance().GetUserName());
            userTotalResultDic.Add(UserData.GetInstance().GetUserName(), uiPlayerTotalResultSlots[0]);
            List<string> userInfos = BattleManager.GetInstance().GetMatchUserInfos();
            for (int count = 1; count <= userInfos.Count; count++)
            {
                uiPlayerTotalResultSlots[count].gameObject.SetActive(true);
                uiPlayerTotalResultSlots[count].SetName(userInfos[count - 1]);
                userTotalResultDic.Add(userInfos[count - 1], uiPlayerTotalResultSlots[count]);
            }
            for (int count = userInfos.Count + 1; count < uiPlayerTotalResultSlots.Length; count++)
            {
                uiPlayerTotalResultSlots[count].gameObject.SetActive(false);
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
