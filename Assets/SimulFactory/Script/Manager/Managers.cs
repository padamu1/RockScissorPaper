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

    public class Managers : MonoSingleton<Managers>
    {
        private MasterContext _masterContext;
        private void Awake()
        {
            Init();
        }
        /// <summary>
        /// �ʱ� ����
        /// </summary>
        private void Init()
        {
            // ContextHolder Setting
            ContextHolder contextHolder = this.gameObject.AddComponent<ContextHolder>();
            _masterContext = new MasterContext();
            contextHolder.Context = _masterContext;

            // �ʼ� ��� ����
            EventManager.GetInstance();
            WorldManager.GetInstance();
            UserData.GetInstance();
            ObjectPoolManager.GetInstance();
            LoadingManager.GetInstance();
            SocketManager.GetInstance();
            //BattleManager.GetInstance(); -> �̰� ������Ʈ�� �����;���
        }
        /// <summary>
        /// Ư�� ������ �ε�
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        /// <summary>
        /// ���� ���۽� ������ ������ ���ؽ�Ʈ ȣ��
        /// </summary>
        /// <returns>������ ���ؽ�Ʈ</returns>
        public MasterContext GetMasterContext()
        {
            return _masterContext;
        }
    }
}
