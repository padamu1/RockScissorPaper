using SimulFactory.Context.Bean;
using SimulFactory.Game.Event;
using SimulFactory.Script.Util;
using SimulFactory.System.Common;
using SimulFactory.Ui.Battle;
using Slash.Unity.DataBind.Core.Presentation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SimulFactory.Manager
{
    public class UiManager : MonoSingleton<UiManager>
    {
        [SerializeField] private GameObject lobbyCanvas; 
        [SerializeField] private FriendUIManager friendUIManager;
        private UiPlayerResultPanel uiPlayerResultPanel;
        private UiPlayerControlPanel uiPlayerControlPanel;
        private UiPlayerTotalResultPanel uiPlayerTotalResultPanel;
        private bool isInit = false;
        private MasterContext masterContext;
        private void Awake()
        {
            GetInstance();
           // this.gameObject.SetActive(false);
        }
        public void Init()
        {
            if(isInit == false)
            {
                isInit = true;
                CoroutineHelper.StartLogoStopCoroutine(SendPing());
                // 컨텍스트 세팅
                ContextHolder contextHolder = this.gameObject.AddComponent<ContextHolder>();

                masterContext = Managers.GetInstance().GetMasterContext();
                contextHolder.Context = masterContext;
            }
            //lobbyCanvas.SetActive(true);
            // 로그인 완료 보냄
            StartCoroutine(SetUi());
        }
        private IEnumerator SetUi()
        {
            friendUIManager.Init();
            yield return null;
            //GetBattleManager().Init();
            yield return null;
            C_LoginComplete.LoginCompleteC();
        }
        private IEnumerator SendPing()
        {
            while (true)
            {
                C_Ping.PingC();
                yield return CoroutineHelper.GetWaitForSeconds(1f);
            }
        }

        #region Regist Panel
        public void RegistUiPlayerResultPanel(UiPlayerResultPanel uiPlayerResultPanel) => this.uiPlayerResultPanel = uiPlayerResultPanel;
        public void RegistUiPlayerControlPanel(UiPlayerControlPanel uiPlayerControlPanel) => this.uiPlayerControlPanel = uiPlayerControlPanel;
        public void RegistUiPlayerTotalResultPanel(UiPlayerTotalResultPanel uiPlayerTotalResultPanel) => this.uiPlayerTotalResultPanel = uiPlayerTotalResultPanel;
        #endregion

        #region Get Registed Panel
        public UiPlayerResultPanel GetUiPlayerResultPanel() => this.uiPlayerResultPanel;
        public UiPlayerControlPanel GetUiPlayerControlPanel() => this.uiPlayerControlPanel;
        public UiPlayerTotalResultPanel GetUiPlayerTotalResultPanel() => this.uiPlayerTotalResultPanel;
        #endregion

        public void StopButtonClicked()
        {
            ResetGameStartButton();
            C_MatchingCancel.MatchingCancelC();
        }
        public void MatchSuccess()
        {
            PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
            popupInfo.Type = System.Common.Define.POPUP_TYPE.YesNoPopup;
            popupInfo.Title = "매칭 성공";
            popupInfo.Description = "매칭을 수락하시겠습니까?";
            popupInfo.Block = true;
            popupInfo.Top = true;
            popupInfo.NoButtonText = "거절";
            popupInfo.YesButtonText = "수락";
            popupInfo.NoButtonAction = delegate { AcceptButtonClicked(false); };
            popupInfo.YesButtonAction = delegate { AcceptButtonClicked(true); };
            popupInfo.SetTimer = true;
            popupInfo.SettingTime = Define.MATCH_USER_WAIT_TIME;
            PopupManager.GetInstance().CreatePopup(popupInfo);
            //matchObj.SetActive(true);
            Debug.Log("매칭 성공");
        }
        public void MatchResultUiActivate()
        {
            Debug.Log("매칭 시작 성공");
            this.gameObject.SetActive(false);
            BattleManager.GetInstance().InvokeMatchingHideAction();
            Managers.GetInstance().LoadScene("Battle");
        }
        public void AcceptButtonClicked(bool isAccept)
        {
            C_MatchingResponse.MatchingResponseC(isAccept);
        }
        /// <summary>
        /// 게임 시작 버튼 리셋
        /// </summary>
        public void ResetGameStartButton()
        {
        }
        public void StopGameUi()
        {
            this.gameObject.SetActive(true);
            Managers.GetInstance().LoadScene("GameMain");
        }
        // 친구요청 버튼클릭
        public void FriendRequestButtonClicked(string userName)
        {
            C_FriendRequest.FriendRequestC(userName);
        }
        public FriendUIManager GetFriendUiManager()
        {
            return friendUIManager;
        }
        public void CreateUserInvitePopup()
        {
            PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
            popupInfo.Type = Define.POPUP_TYPE.InputPopup;
            popupInfo.Title = "유저 초대";
            popupInfo.WarningText = "현재 접속중인 유저만 초대 가능합니다.";
            popupInfo.NoButtonText = "취소";
            popupInfo.YesButtonText = "초대";
            popupInfo.InputAction = C_InviteUser.InviteUserC;
            popupInfo.Top = true;
            popupInfo.Block = true;
            PopupManager.GetInstance().CreatePopup(popupInfo);
        }
    }
}
