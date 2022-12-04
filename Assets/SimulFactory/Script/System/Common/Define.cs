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
            LoginC = 0,                     // �α��� ��û
            StartMatchingC = 1,             // ��Ī ��û
            MatchingResponseC = 2,          // ��Ī ����
            MatchingCancelC = 3,            // ��Ī ��� ��û
            PingC = 4,                      // ������ �ֱ������� ���� Ȯ���� ���� ���� ����
            UserBattleButtonClickedC = 5,   // ��Ʋ �� ������ Ŭ���� ��ư�� ����
            UserNameC = 6,                  // ���� �г��� ���� ��û
            LoginCompleteC = 7,             // ���� �α��� �Ϸ� �޽���
            FriendRequestC = 8,             // ģ�� ��û
            FriendRemoveC = 9,              // ģ�� ����
            FriendReceiveC = 10,            // ģ�� ��û ���� ��� ����
            ChatC = 11,                     // ä�� �Է�
            InviteUserC = 12,               // ���� �ʴ�
            InviteReceiveC = 13,            // �ʴ� ����

            LoginS = 0,             // �α��� ����
            UserInfoS = 1,          // ���� ���� ������
            StartMatchingS = 2,     // ��Ī ���� ���� -> ���� / ����
            MatchingSuccessS = 3,   // ��Ī ������ Ŭ���̾�Ʈ�� ������
            MatchingResponseS = 4,  // ��Ī ���� ���信 ���� �亯 -> ���� / ����
            MatchingCancelS = 5,    // ��Ī ��� ��û ����
            MatchingResultS = 6,    // ��Ī ��� ����
            UserBattleResponseS = 7,// ������� �� ����� ����
            RoundResultS = 8,       // ���� ��� ����
            UserNameS = 9,          // ���� �г��� ���� ��û ����
            FriendRequestS = 10,    // ģ�� ��û�� ���� ��� �� ���濡�� ģ�� ��û ����
            FriendRemoveS = 11,     // ģ�� ����
            FriendReceiveS = 12,    // ģ�� ��û ���� ����� ���� ���� ���濡�� ����
            FriendDataS = 13,       // ģ�� ������ ����
            ChatS = 14,             // ä�� ����
            InviteUserS = 15,       // �ʴ� ����
            InviteReceiveS = 16,    // �ʴ� ���信 ���� ���
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
            Tie = 3,   // ���º��϶�
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
            Toast = 0,   // �佺Ʈ �˾� -> �ý��� �޽���
            None = 1,    // �Ϲ� ä��
            Whisper = 2, // �ӼӸ�
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
