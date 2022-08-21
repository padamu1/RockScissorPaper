using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimulFactory.Manager;

public class BaseObject : MonoBehaviour
{
    protected void OnDisable()
    {
        ObjectPoolManager.GetInstance().ReturnToPool(this.gameObject);
    }
}
