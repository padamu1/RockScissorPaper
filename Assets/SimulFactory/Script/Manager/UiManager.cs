using SimulFactory.Context.Bean;
using SimulFactory.Game.Event;
using SimulFactory.Script.Util;
using SimulFactory.System.Common;
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
        [SerializeField] private GameObject startButton; 
        [SerializeField] private GameObject stopButton;
        [SerializeField] private GameObject matchObj;
        [SerializeField] private GameObject uiHolder;
        [SerializeField] private BattleManager battleManager;

        private MasterContext masterContext;
        private void Awake()
        {
            GetInstance();
        }
        public void Init()
        {
            CoroutineHelper.StartLogoStopCoroutine(SendPing());
            // 컨텍스트 세팅
            ContextHolder contextHolder = this.gameObject.AddComponent<ContextHolder>();

            masterContext = Managers.GetInstance().GetMasterContext();
            contextHolder.Context = masterContext;


            // 메인 ui 설정
            startButton.gameObject.SetActive(true);
            stopButton.gameObject.SetActive(false);
            matchObj.SetActive(false);
            //lobbyCanvas.SetActive(true);
            // 로그인 완료 보냄
            StartCoroutine(SetUi());
        }
        private IEnumerator SetUi()
        {
            yield return null;
            GetBattleManager().Init();
            yield return null;
            C_LoginComplete.LoginCompleteC();
        }
        private IEnumerator SendPing()
        {
            while(true)
            {
                C_Ping.PingC();
                yield return CoroutineHelper.GetWaitForSeconds(1f);
            }
        }
        public void StartNormalButtonClicked()
        {
            startButton.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(true);
            C_StartMatching.StartMatchingC((int)Define.MATCH_TYPE.Normal);
        }
        public void StartMultiButtonClicked()
        {
            startButton.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(true);
            C_StartMatching.StartMatchingC((int)Define.MATCH_TYPE.Multi);
        }
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
            PopupManager.GetInstance().CreatePopup(popupInfo);
            //matchObj.SetActive(true);
            Debug.Log("매칭 성공");
        }
        public void MatchResultUiActivate()
        {
            Debug.Log("매칭 시작 성공");
            startButton.SetActive(false);
            stopButton.SetActive(false);
            battleManager.gameObject.SetActive(true);
            battleManager.ButtonActivate();
        }
        public void AcceptButtonClicked(bool isAccept)
        {
            matchObj.SetActive(false);
            C_MatchingResponse.MatchingResponseC(isAccept);
        }
        /// <summary>
        /// 게임 시작 버튼 리셋
        /// </summary>
        public void ResetGameStartButton()
        {
            startButton.gameObject.SetActive(true);
            stopButton.gameObject.SetActive(false);
        }
        public void StopGameUi()
        {
            battleManager.gameObject.SetActive(false);
        }
        // 친구요청 버튼클릭
        public void FriendRequestButtonClicked(string userName)
        {
            C_FriendRequest.FriendRequestC(userName);
        }
        public BattleManager GetBattleManager()
        {
            return battleManager;
        }
    }
}
