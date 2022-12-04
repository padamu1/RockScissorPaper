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
            ToastPopup,
        }

        public enum EVENT_CODE
        {
            LoginC = 0,                     // 로그인 요청
            StartMatchingC = 1,             // 매칭 요청
            MatchingResponseC = 2,          // 매칭 응답
            MatchingCancelC = 3,            // 매칭 취소 요청
            PingC = 4,                      // 서버에 주기적으로 접속 확인을 위한 핑을 보냄
            UserBattleButtonClickedC = 5,   // 배틀 중 유저가 클릭한 버튼을 보냄
            UserNameC = 6,                  // 유저 닉네임 변경 요청
            LoginCompleteC = 7,             // 유저 로그인 완료 메시지
            FriendRequestC = 8,             // 친구 요청
            FriendRemoveC = 9,              // 친구 삭제
            FriendReceiveC = 10,            // 친구 요청 수락 결과 보냄
            ChatC = 11,                     // 채팅 입력
            InviteUserC = 12,               // 유저 초대
            InviteReceiveC = 13,            // 초대 응답

            LoginS = 0,             // 로그인 응답
            UserInfoS = 1,          // 유저 정보 내려줌
            StartMatchingS = 2,     // 매칭 시작 응답 -> 성공 / 실패
            MatchingSuccessS = 3,   // 매칭 성공시 클라이언트에 내려줌
            MatchingResponseS = 4,  // 매칭 수락 응답에 대한 답변 -> 성공 / 실패
            MatchingCancelS = 5,    // 매칭 취소 요청 응답
            MatchingResultS = 6,    // 매칭 결과 전송
            UserBattleResponseS = 7,// 상대편이 낸 결과를 받음
            RoundResultS = 8,       // 라운드 결과 전송
            UserNameS = 9,          // 유저 닉네임 변경 요청 응답
            FriendRequestS = 10,    // 친구 요청에 대한 결과 및 상대방에게 친구 요청 보냄
            FriendRemoveS = 11,     // 친구 삭제
            FriendReceiveS = 12,    // 친구 요청 수락 결과에 대한 것을 상대방에게 보냄
            FriendDataS = 13,       // 친구 데이터 보냄
            ChatS = 14,             // 채팅 받음
            InviteUserS = 15,       // 초대 받음
            InviteReceiveS = 16,    // 초대 응답에 대한 결과
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
            Nature,
        }
        public enum CONTEXT_LIST
        {
            UserInfo,
            MatchInfo,
            RockScissorPaper,
            Setting,
        }

        public enum ROCK_SCISSOR_PAPER
        {
            Break = -2,
            None = -1,
            Rock = 0,
            Scissor = 1,
            Paper = 2,
            Tie = 3,   // 무승부일때
        }
        public enum POPUP_TYPE
        { 
            YesNoPopup,
            ToastPopup,
        }

        public enum MATCH_TYPE
        {
            Normal = 0,
            Multi = 1,
            Card = 2,
        }

        public enum RECEIVE_DATA_TYPE
        {
            Me = 0,
            Other = 1,
        }
        public enum CHAT_TYPE
        {
            Toast = 0,   // 토스트 팝업 -> 시스템 메시지
            None = 1,    // 일반 채팅
            Whisper = 2, // 귓속말
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
