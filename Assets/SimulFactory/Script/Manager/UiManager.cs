using SimulFactory.Game.Event;
using SimulFactory.Script.Util;
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
        [SerializeField] private GameObject startButton; 
        [SerializeField] private GameObject stopButton;
        [SerializeField] private GameObject matchObj;
        [SerializeField] private GameObject uiHolder;
        private GameObject gameUi;
        private void Awake()
        {
            GetInstance();
        }
        public void Init()
        {
            // 게임 ui 설정
            gameUi = Instantiate(Resources.Load("Ui/GameUI") as GameObject,uiHolder.transform);
            gameUi.SetActive(false);

            CoroutineHelper.StartLogoStopCoroutine(SendPing());
            // 컨텍스트 세팅
            ContextHolder contextHolder = this.gameObject.AddComponent<ContextHolder>();
            contextHolder.Context = Managers.GetInstance().GetMasterContext();

            // 메인 ui 설정
            startButton.gameObject.SetActive(true);
            stopButton.gameObject.SetActive(false);
            matchObj.SetActive(false);
        }
        private IEnumerator SendPing()
        {
            while(true)
            {
                C_Ping.PingC();
                yield return CoroutineHelper.GetWaitForSeconds(1f);
            }
        }
        public void StartButtonClicked()
        {
            startButton.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(true);
            C_StartMatching.StartMatchingC();
        }
        public void StopButtonClicked()
        {
            ResetGameStartButton();
            C_MatchingCancel.MatchingCancelC();
        }
        public void MatchSuccess()
        {
            matchObj.SetActive(true);
            Debug.Log("매칭 성공");
        }
        public void MatchResultUiActivate()
        {
            Debug.Log("매칭 시작 성공");
            startButton.SetActive(false);
            stopButton.SetActive(false);
            gameUi.SetActive(true);
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
            gameUi.SetActive(false);
        }
    }
}
