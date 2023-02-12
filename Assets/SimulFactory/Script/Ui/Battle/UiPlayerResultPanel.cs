using SimulFactory.Manager;
using SimulFactory.System.Common;
using SimulFactory.Ui.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.Ui.Battle
{
    public class UiPlayerResultPanel : MonoBehaviour, IRegistPanel
    {
        [SerializeField] private UiPlayerResultSlot[] uiPlayerResultSlots;
        [SerializeField] private UiPlayerResultSlot myResultSlot;
        [SerializeField] private Sprite[] resultSprites;                        // 사전에 정의된 결과 이미지 -> 각 이미지 순서는 Define에 정의된 순서에 맞춤

        private Dictionary<string, UiPlayerResultSlot> playerResultDic;
        private void OnEnable()
        {
            RegistPanelThisPanel();
            SetMyResultSlot();
            SetUserCount();
            myResultSlot.ResetResult();
        }
        public void RegistPanelThisPanel()
        {
            UiManager.GetInstance().RegistUiPlayerResultPanel(this);
        }
        // 내 슬롯 설정 이름을 표시할 필요가 없으므로 이름 표시 안함
        private void SetMyResultSlot() => myResultSlot.SetName(string.Empty);
        /// <summary>
        /// 참가한 유저 숫자에 맞게 현재 패널 설정
        /// </summary>
        private void SetUserCount()
        {
            playerResultDic = new Dictionary<string, UiPlayerResultSlot>();
            List<string> userInfos = BattleManager.GetInstance().GetMatchUserInfos();
            for (int count = 0; count < userInfos.Count; count++)
            {
                uiPlayerResultSlots[count].gameObject.SetActive(true);
                uiPlayerResultSlots[count].SetName(userInfos[count]);
                uiPlayerResultSlots[count].ResetResult();
                playerResultDic.Add(userInfos[count], uiPlayerResultSlots[count]);
            }
            for(int count = userInfos.Count; count < uiPlayerResultSlots.Length; count++)
            {
                uiPlayerResultSlots[count].gameObject.SetActive(false);
            }
        }
        private Sprite GetResultSprite(int resultCode) => resultSprites[resultCode];
        /// <summary>
        /// 각 유저의 결과 설정
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="resultCode"></param>
        public void SetResult(string userName, int resultCode)
        {
            if (playerResultDic.ContainsKey(userName))
            {
                // 결과 설정
                playerResultDic[userName].SetResult(GetResultSprite(resultCode));
            }
        }
        // 내 결과 설정
        public void SetMyResult(int resultCode) => myResultSlot.SetResult(GetResultSprite(resultCode));
        public bool GetMyResult() => myResultSlot.GetResult();
        public void ResetResult()
        {
            for(int count = 0; count < uiPlayerResultSlots.Length; count++)
            {
                uiPlayerResultSlots[count].ResetResult();
            }
            myResultSlot.ResetResult();
        }
    }

}