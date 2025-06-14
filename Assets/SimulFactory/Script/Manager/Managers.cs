using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimulFactory.Manager
{
    using Slash.Unity.DataBind.Core.Presentation;
    using Slash.Unity.DataBind.Core.Data;
    using SimulFactory.Context.Bean;
    using global::System;
    using UnityEngine.Events;
    using SimulFactory.Game.Event;

    public class Managers : MonoSingleton<Managers>
    {
        private MasterContext _masterContext;
        private void Awake()
        {
            Init();
        }
        private void OnApplicationQuit()
        {
            SocketManager.GetInstance().Disconnect();
        }
        /// <summary>
        /// 초기 설정
        /// </summary>
        private void Init()
        {
#if UNITY_EDITOR
            Application.runInBackground = true;
#endif
            // ContextHolder Setting
            ContextHolder contextHolder = this.gameObject.AddComponent<ContextHolder>();
            _masterContext = new MasterContext();
            contextHolder.Context = _masterContext;

            EventManager.GetInstance();
            WorldManager.GetInstance();
            UserData.GetInstance();
            ObjectPoolManager.GetInstance();
            LoadingManager.GetInstance();
            SocketManager.GetInstance();
            WorldManager.GetInstance();
            SpriteAtlasManager.GetInstance();
            //BattleManager.GetInstance(); -> 이거 오브젝트로 가져와야함
        }
        /// <summary>
        /// 특정 씬으로 로딩
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        /// <summary>
        /// 게임 시작시 생성된 마스터 컨텍스트 호출
        /// </summary>
        /// <returns>마스터 컨텍스트</returns>
        public MasterContext GetMasterContext()
        {
            return _masterContext;
        }
    }
}
