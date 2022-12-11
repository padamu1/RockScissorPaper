using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimulFactory.System.Common;

namespace SimulFactory.Manager
{
    public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
    {
        private Dictionary<string, Queue<GameObject>> poolDic;
        private Dictionary<string, GameObject> objectDic;
        private void Awake()
        {
            poolDic = new Dictionary<string, Queue<GameObject>>();
            objectDic = new Dictionary<string, GameObject>();
        }
        public void SetPool(GameObject obj, int setObjCount)
        {
            if (objectDic.ContainsKey(obj.name)) return;

            poolDic.Add(obj.name, new Queue<GameObject>());
            objectDic.Add(obj.name, obj);
            for(int count = 0; count < setObjCount; count++)
            {
                GameObject tempObj = Instantiate(obj);
                tempObj.name = obj.name;
                tempObj.SetActive(false);
            }
        }
        public GameObject SpawnFromPool(string objectName)
        {
            if (!poolDic.ContainsKey(objectName)) return null;

            GameObject obj;
            if (poolDic[objectName].Count == 0)
            {
                obj = Instantiate(objectDic[objectName]);
                obj.name = objectName;
            }
            else
            {
                obj = poolDic[objectName].Dequeue();
                obj.SetActive(true);
            }
            return obj;
        }
        public void ReturnToPool(GameObject obj)
        {
            if(poolDic.ContainsKey(obj.name))
            {
                poolDic[obj.name].Enqueue(obj);
            }
        }
        public void ReturnToAllPool()
        {
            // WorldManager에서 풀 리스트를 전부 관리하도록 설정해야함.
        }
    }

}
