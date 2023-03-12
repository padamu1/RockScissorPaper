using SimulFactory.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUIParticle : MonoBehaviour
{
    public GameObject particle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            particle.SetActive(false);
            Debug.Log("Å¬¸¯");
            AudioSourceManager.GetInstance().PlayOnShotEffect("click");

            particle.transform.position = Input.mousePosition;
            particle.SetActive(true);
        }
    }
}
