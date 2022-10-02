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
            LoginC = 0,                     // �α��� ��û
            StartMatchingC = 1,             // ��Ī ��û
            MatchingResponseC = 2,          // ��Ī ����
            MatchingCancelC = 3,            // ��Ī ��� ��û
            PingC = 4,                      // ������ �ֱ������� ���� Ȯ���� ���� ���� ���� -> �Ⱥ����� �������� ����
            UserBattleButtonClicked = 5,    // ��Ʋ �� ������ Ŭ���� ��ư�� ����

            LoginS = 0,             // �α��� ����
            UserInfoS = 1,          // ���� ���� ������
            StartMatchingS = 2,     // ��Ī ���� ���� -> ���� / ����
            MatchingSuccessS = 3,   // ��Ī ������ Ŭ���̾�Ʈ�� ������
            MatchingResponseS = 4,  // ��Ī ���� ���信 ���� �亯 -> ���� / ����
            MatchingCancelS = 5,    // ��Ī ��� ��û ����
            MatchingResultS = 6,    // ��Ī ��� ����
            UserBattleResponseS = 7,// ������� �� ����� ����
            RoundResultS = 8,       // ���� ��� ����
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
        // PlayerPrefs ����
        public static readonly string PLAYERPREFS_USER_NO = "USER_NO";
        public static readonly int POPUP_TOP_START_ORDER = 100;
        public static readonly int POPUP_TOP_END_ORDER = 400;
    }

}
