using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.System.Common
{
    public class Define : MonoBehaviour
    {
        public enum UnityEvent
        {
            TEST_EVENT= 1,
            TEST_EVENT2= 2,

        }
        public enum EventCode
        {
            ServerInfoS = 1,    // �������� ������ ���� �� ���
        }
        public enum HapticType
        {
            ShortHaptic,
            LongHaptic,
        }
        public enum AudioSourceType
        {
            Effect,
            BackGround,
            Voice,
            Nature
        }
    }

}
