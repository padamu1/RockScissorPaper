using SimulFactory.Context;
using SimulFactory.Context.Bean;
using SimulFactory.Game.Event;
using SimulFactory.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;

namespace SimulFactory.Manager
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private GameObject contextHolder;
        [SerializeField] private Sprite rockImg;
        [SerializeField] private Sprite scissorImg;
        [SerializeField] private Sprite paperImg;
        private RockScissorPaperDic _rockScissorPaperDic;   // 컨텍스트 딕셔너리
        private string _selectButtonName;                   // 선택된 버튼 이름
        private bool _isRoundReady;
        /// <summary>
        /// 게임 입장 전 호출 되어야 함
        /// </summary>
        public void Init()
        {
            MasterContext masterContext = Managers.GetInstance().GetMasterContext();
            _rockScissorPaperDic = new RockScissorPaperDic();
            masterContext.Master.Add(Define.CONTEXT_LIST.RockScissorPaper.ToString(), _rockScissorPaperDic);
            //rockImg = Resources.Load<Sprite>("Resources/Element/Hands/RockHand");
            //scissorImg = Resources.Load<Sprite>("Resources/Element/Hands/ScissorHand");
            //paperImg = Resources.Load<Sprite>("Resources/Element/Hands/PaperHand");
            GameButtonSetting();

            ButtonDeactivate();
        }

        /// <summary>
        /// 각 게임 버튼 기능 사전 세팅
        /// </summary>
        private void GameButtonSetting()
        {
            _rockScissorPaperDic.RockScissorPaper.Add(Define.ROCK_BUTTON, RockButtonSetting());
            _rockScissorPaperDic.RockScissorPaper.Add(Define.SCISSOR_BUTTON, ScissorButtonSetting());
            _rockScissorPaperDic.RockScissorPaper.Add(Define.PAPER_BUTTON, PaperButtonSetting());
        }
        /// <summary>
        /// 바위 버튼 세팅
        /// </summary>
        /// <returns>RockScissorPaper</returns>
        private RockScissorPaper RockButtonSetting()
        {
            RockScissorPaper rockScissorPaper = new RockScissorPaper();
            rockScissorPaper.SlotButtonAction = delegate { ButtonClicked((int)Define.ROCK_SCISSOR_PAPER.Rock); };
            rockScissorPaper.SlotButtonText = Define.ROCK_SCISSOR_PAPER.Rock.ToString();
            rockScissorPaper.SlotButtonImg = rockImg;
            rockScissorPaper.SlotButtonState = false;
            return rockScissorPaper;
        }
        /// <summary>
        /// 가위 버튼 세팅
        /// </summary>
        /// <returns>RockScissorPaper</returns>
        private RockScissorPaper ScissorButtonSetting()
        {
            RockScissorPaper rockScissorPaper = new RockScissorPaper();
            rockScissorPaper.SlotButtonAction = delegate { ButtonClicked((int)Define.ROCK_SCISSOR_PAPER.Scissor); };
            rockScissorPaper.SlotButtonText = Define.ROCK_SCISSOR_PAPER.Scissor.ToString();
            rockScissorPaper.SlotButtonImg = scissorImg;
            rockScissorPaper.SlotButtonState = false;
            return rockScissorPaper;
        }
        /// <summary>
        /// 보자기 버튼 세팅
        /// </summary>
        /// <returns>RockScissorPaper</returns>
        private RockScissorPaper PaperButtonSetting()
        {
            RockScissorPaper rockScissorPaper = new RockScissorPaper();
            rockScissorPaper.SlotButtonAction = delegate { ButtonClicked((int)Define.ROCK_SCISSOR_PAPER.Paper); };
            rockScissorPaper.SlotButtonText = Define.ROCK_SCISSOR_PAPER.Paper.ToString();
            rockScissorPaper.SlotButtonImg = paperImg;
            rockScissorPaper.SlotButtonState = false;
            return rockScissorPaper;
        }
        private void RebuildHolder()
        {
            contextHolder.SetActive(false);
            contextHolder.SetActive(true);
        }
        /// <summary>
        /// 버튼이 눌렸을 때 수행될 동작
        /// </summary>
        /// <param name="buttonName"></param>
        private void ButtonClicked(int buttonNo)
        {
            if(_isRoundReady)
            {
                C_UserBattleButtonClicked.UserBattleButtonClickedC(buttonNo);
                ButtonDeactivate();
            }
        }
        /// <summary>
        /// 버튼 클릭 준비
        /// </summary>
        public void ButtonActivate()
        {
            _isRoundReady = true;
            ButtonStateChange(_isRoundReady);
            RebuildHolder();
        }
        /// <summary>
        /// 버튼을 비활성화 시킴
        /// </summary>
        public void ButtonDeactivate()
        {
            _isRoundReady = false;
            ButtonStateChange(_isRoundReady);
            RebuildHolder();
        }

        public void ButtonStateChange(bool state)
        {
            _rockScissorPaperDic.RockScissorPaper[Define.ROCK_BUTTON].SlotButtonState = state;
            _rockScissorPaperDic.RockScissorPaper[Define.SCISSOR_BUTTON].SlotButtonState = state;
            _rockScissorPaperDic.RockScissorPaper[Define.PAPER_BUTTON].SlotButtonState = state;
        }
        public Sprite GetRockImg()
        {
            return rockImg;
        }
        public Sprite GetScissorImg()
        {
            return scissorImg;
        }
        public Sprite GetPaperImg()
        {
            return paperImg;
        }
    }
}
