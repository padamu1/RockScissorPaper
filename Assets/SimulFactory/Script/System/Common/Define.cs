using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.System.Common
{
    public class Define : MonoBehaviour
    {
        public enum UNOTY_EVENT
        {

        }
        public enum EVENT_CODE
        {
            PlayerNameC = 0,
            ServerInfoS = 1,    // �������� ������ ���� �� ���
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
