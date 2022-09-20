using SimulFactory.Context;
using SimulFactory.Context.Bean;
using SimulFactory.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulFactory.Manager
{
    public class BattleManager : MonoSingleton<BattleManager>
    {
        private RockScissorPaperDic _rockScissorPaperDic;   // 컨텍스트 딕셔너리
        private string _selectButtonName;                   // 선택된 버튼 이름
        /// <summary>
        /// 게임 입장 전 호출 되어야 함
        /// </summary>
        public void Init()
        {
            MasterContext masterContext = Managers.GetInstance().GetMasterContext();
            _rockScissorPaperDic = new RockScissorPaperDic();
            masterContext.Master.Add(Define.CONTEXT_LIST.RockScissorPaper.ToString(), _rockScissorPaperDic);

            GameButtonSetting();
        }

        /// <summary>
        /// 각 게임 버튼 기능 사전 세팅
        /// </summary>
        private void GameButtonSetting()
        {
            _rockScissorPaperDic.RockScissorPaper.Add(Define.ROCK_BUTTON, RockButtonSetting(new RockScissorPaper()));
            _rockScissorPaperDic.RockScissorPaper.Add(Define.SCISSOR_BUTTON, ScissorButtonSetting(new RockScissorPaper()));
            _rockScissorPaperDic.RockScissorPaper.Add(Define.PAPER_BUTTON, PaperButtonSetting(new RockScissorPaper()));
        }
        /// <summary>
        /// 바위 버튼 세팅
        /// </summary>
        /// <returns>RockScissorPaper</returns>
        private RockScissorPaper RockButtonSetting(RockScissorPaper rockScissorPaper)
        {
            rockScissorPaper.SlotButtonAction = delegate { ButtonClicked(Define.ROCK_BUTTON); };
            rockScissorPaper.SlotButtonText = Define.ROCK_BUTTON;
            rockScissorPaper.SlotButtonImg = null;
            return rockScissorPaper;
        }
        /// <summary>
        /// 가위 버튼 세팅
        /// </summary>
        /// <returns>RockScissorPaper</returns>
        private RockScissorPaper ScissorButtonSetting(RockScissorPaper rockScissorPaper)
        {
            rockScissorPaper.SlotButtonAction = delegate { ButtonClicked(Define.SCISSOR_BUTTON); };
            rockScissorPaper.SlotButtonText = Define.SCISSOR_BUTTON;
            rockScissorPaper.SlotButtonImg = null;
            return rockScissorPaper;
        }
        /// <summary>
        /// 보자기 버튼 세팅
        /// </summary>
        /// <returns>RockScissorPaper</returns>
        private RockScissorPaper PaperButtonSetting(RockScissorPaper rockScissorPaper)
        {
            rockScissorPaper.SlotButtonAction = delegate { ButtonClicked(Define.PAPER_BUTTON); };
            rockScissorPaper.SlotButtonText = Define.PAPER_BUTTON;
            rockScissorPaper.SlotButtonImg = null;
            return rockScissorPaper;
        }
        /// <summary>
        /// 버튼이 눌렸을 때 수행될 동작
        /// </summary>
        /// <param name="buttonName"></param>
        private void ButtonClicked(string buttonName)
        {
            // 서버에 메시지 전송
        }
    }
}
