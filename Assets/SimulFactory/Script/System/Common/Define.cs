using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.System.Common
{
    public class Define : MonoBehaviour
    {
        public enum UNITY_EVENT
        {

        }
        public enum EVENT_CODE
        {
            LoginC = 0,             // �α��� ��û
            StartMatchingC = 1,     // ��Ī ��û
            MatchingResponseC = 2,  // ��Ī ����
            MatchingCancelC = 3,    // ��Ī ��� ��û

            LoginS = 0,             // �α��� ����
            UserInfoS = 1,          // ���� ���� ������
            StartMatchingS = 2,     // ��Ī ���� ���� -> ���� / ����
            MatchingSuccessS = 3,   // ��Ī ������ Ŭ���̾�Ʈ�� ������
            MatchingResponseS = 4,  // ��Ī ���� ���信 ���� �亯 -> ���� / ����
            MatchingCancelS = 5,    // ��Ī ��� ��û ����
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
    }

}
