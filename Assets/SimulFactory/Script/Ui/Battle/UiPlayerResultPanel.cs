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
        [SerializeField] private Sprite[] resultSprites;                        // ������ ���ǵ� ��� �̹��� -> �� �̹��� ������ Define�� ���ǵ� ������ ����

        private Dictionary<string, UiPlayerResultSlot> playerResultDic;
        private void OnEnable()
        {
            RegistPanelThisPanel();
            SetMyResultSlot();
            SetUserCount();
        }
        public void RegistPanelThisPanel()
        {
            UiManager.GetInstance().RegistUiPlayerResultPanel(this);
        }
        // �� ���� ���� �̸��� ǥ���� �ʿ䰡 �����Ƿ� �̸� ǥ�� ����
        private void SetMyResultSlot() => myResultSlot.SetName(string.Empty);
        /// <summary>
        /// ������ ���� ���ڿ� �°� ���� �г� ����
        /// </summary>
        private void SetUserCount()
        {
            playerResultDic = new Dictionary<string, UiPlayerResultSlot>();
            List<string> userInfos = BattleManager.GetInstance().GetMatchUserInfos();
            for (int count = 0; count < userInfos.Count; count++)
            {
                uiPlayerResultSlots[count].gameObject.SetActive(true);
                uiPlayerResultSlots[count].SetName(userInfos[count]);
                playerResultDic.Add(userInfos[count], uiPlayerResultSlots[count]);
            }
        }
        private Sprite GetResultSprite(int resultCode) => resultSprites[resultCode];
        /// <summary>
        /// �� ������ ��� ����
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="resultCode"></param>
        public void SetResult(string userName, int resultCode)
        {
            if (playerResultDic.ContainsKey(userName))
            {
                // ��� ����
                playerResultDic[userName].SetResult(GetResultSprite(resultCode));
            }
        }
        // �� ��� ����
        public void SetMyResult(int resultCode) => myResultSlot.SetResult(GetResultSprite(resultCode));

    }

}