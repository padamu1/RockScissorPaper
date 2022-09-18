using SimulFactory.Game.Event;
using System;
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
        [SerializeField] private GameObject MatchObj;

        private void Awake()
        {
            GetInstance();
        }
        public void Init()
        {
            startButton.gameObject.SetActive(true);
            stopButton.gameObject.SetActive(false);
            MatchObj.SetActive(false);
        }
        public void StartButtonClicked()
        {
            startButton.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(true);
            C_StartMatching.StartMatchingC();
        }
        public void StopButtonClicked()
        {
            startButton.gameObject.SetActive(true);
            stopButton.gameObject.SetActive(false);
            C_MatchingCancel.MatchingCancelC();
        }
        public void MatchSuccess()
        {
            MatchObj.SetActive(true);
            Debug.Log("매칭 성공");
        }
        public void MatchingReponse(int result)
        {
            if (result == 1)
            {
                Debug.Log("매칭 시작 실패");
                startButton.gameObject.SetActive(true);
                stopButton.gameObject.SetActive(false);
                return;
            }

            Debug.Log("매칭 시작 성공");
        }
        public void AcceptButtonClicked(bool isAccept)
        {
            MatchObj.SetActive(false);
            C_MatchingResponse.MatchingResponseC(isAccept);
        }
    }
}
