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
        public enum EVENT_CODE
        {
            LoginC = 0,             // �α��� ��û
            StartMatchingC = 1,     // ��Ī ��û
            MatchingResponseC = 2,  // ��Ī ����
            MatchingCancelC = 3,    // ��Ī ��� ��û
            PingC = 4,              // ������ �ֱ������� ���� Ȯ���� ���� ���� ���� -> �Ⱥ����� �������� ����

            LoginS = 0,             // �α��� ����
            UserInfoS = 1,          // ���� ���� ������
            StartMatchingS = 2,     // ��Ī ���� ���� -> ���� / ����
            MatchingSuccessS = 3,   // ��Ī ������ Ŭ���̾�Ʈ�� ������
            MatchingResponseS = 4,  // ��Ī ���� ���信 ���� �亯 -> ���� / ����
            MatchingCancelS = 5,    // ��Ī ��� ��û ����
            MatchingResultS = 6,    // ��Ī ��� ����
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

        // ���ؽ�Ʈ ����
        public static readonly string ROCK_BUTTON = "Rock";
        public static readonly string SCISSOR_BUTTON = "Scissor";
        public static readonly string PAPER_BUTTON = "Paper";

        // PlayerPrefs ����
        public static readonly string PLAYERPREFS_USER_NO = "USER_NO";
    }

}
