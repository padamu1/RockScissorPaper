using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.System.Common
{
    public class Define : MonoBehaviour
    {
        public enum UNITY_EVENT
        {
            Login = 0,
        }
        public enum UNIT_PREFAB
        {
            MainPopup,
        }

        public enum EVENT_CODE
        {
            LoginC = 0,                     // 로그인 요청
            StartMatchingC = 1,             // 매칭 요청
            MatchingResponseC = 2,          // 매칭 응답
            MatchingCancelC = 3,            // 매칭 취소 요청
            PingC = 4,                      // 서버에 주기적으로 접속 확인을 위한 핑을 보냄 -> 안보내면 끊어지게 설정
            UserBattleButtonClicked = 5,    // 배틀 중 유저가 클릭한 버튼을 보냄

            LoginS = 0,             // 로그인 응답
            UserInfoS = 1,          // 유저 정보 내려줌
            StartMatchingS = 2,     // 매칭 시작 응답 -> 성공 / 실패
            MatchingSuccessS = 3,   // 매칭 성공시 클라이언트에 내려줌
            MatchingResponseS = 4,  // 매칭 수락 응답에 대한 답변 -> 성공 / 실패
            MatchingCancelS = 5,    // 매칭 취소 요청 응답
            MatchingResultS = 6,    // 매칭 결과 전송
            UserBattleResponseS = 7,// 상대편이 낸 결과를 받음
            RoundResultS = 8,       // 라운드 결과 전송
        }
        public enum HAPTIC_EVET
        {
            ShortHaptic,
            LongHaptic,
        }
        public enum AUDIO_SOURCE_TYPE
        {
            Effect,
            BackGround,
            Voice,
            Nature
        }
        public enum CONTEXT_LIST
        {
            RockScissorPaper,

        }

        public enum ROCK_SCISSOR_PAPER
        {
            Rock = 0,
            Scissor = 1,
            Paper = 2,
        }
        public enum POPUP_TYPE
        { 
            YesNoPopup,
            ToastPopup,
        }


        public static readonly int MAINPOPUP_SET_COUNT = 5;
        public static readonly int TOASTPOPUP_SET_COUNT = 5;
        public static readonly string ROCK_BUTTON = "Rock";
        public static readonly string SCISSOR_BUTTON = "Scissor";
        public static readonly string PAPER_BUTTON = "Paper";
        // PlayerPrefs 관련
        public static readonly string PLAYERPREFS_USER_NO = "USER_NO";
        public static readonly int POPUP_TOP_START_ORDER = 100;
        public static readonly int POPUP_TOP_END_ORDER = 400;
    }

}
