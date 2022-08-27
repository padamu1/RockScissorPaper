using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    public void Activate(GameObject h)
    {
        if(h.activeSelf == true)
        {
            h.SetActive(false);
        }
        else
        {
            h.SetActive(true);
        }
    }

    public void OtherActive(GameObject j)
    {
        if(j.activeSelf == true)
        {
            j.SetActive(false);
        }
    }
}
