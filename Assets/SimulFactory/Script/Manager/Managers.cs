using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }

}
