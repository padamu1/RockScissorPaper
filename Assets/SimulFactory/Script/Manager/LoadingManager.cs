using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimulFactory.Manager
{
    public class LoadingManager : MonoSingleton<LoadingManager>
    {
        [SerializeField] private GameObject loadingObj;
        private bool loadingComplete;
        public void Init()
        {

        }
        public void SetLoading()
        {
            loadingComplete = false;
            loadingObj.SetActive(true);
        }
        public void SetLoadingComplete()
        {
            loadingComplete = true;
        }
        private void Update()
        {

            if(loadingComplete)
            {
                EndLoading();
            }
        }
        private void EndLoading()
        {
            loadingObj.SetActive(false);
        }
    }

}
