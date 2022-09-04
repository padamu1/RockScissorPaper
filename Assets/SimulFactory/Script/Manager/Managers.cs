using SimulFactory.WebSocket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimulFactory.Manager
{
    public class Managers : MonoSingleton<Managers>
    {
        private void Awake()
        {
            Init();
        }
        private void Init()
        {
            EventManager.GetInstance();
            WorldManager.GetInstance();
            ObjectPoolManager.GetInstance();
            LoadingManager.GetInstance();
            SocketManager.GetInstance();
        }
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
