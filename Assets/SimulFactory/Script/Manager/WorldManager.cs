using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using SimulFactory.System.Common;
namespace SimulFactory.Manager
{    
    public class WorldManager : MonoSingleton<WorldManager>, IOnEventCallback
    {
        private Dictionary<byte, object> param;
        private void OnEnable()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        private void OnDisable()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        /// <summary>
        /// 서버의 이벤트 발생시 호출.
        /// </summary>
        /// <param name="photonEvent"></param>
        void IOnEventCallback.OnEvent(EventData photonEvent)
        {
            param = new Dictionary<byte, object>(photonEvent.Parameters.paramDict);
            
            switch((Define.EventCode)photonEvent.Code)
            {
                case Define.EventCode.ServerInfoS:
                    break;
                default:
                    break;
            }
        }

    }
}
