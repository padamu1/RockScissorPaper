using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitch : MonoBehaviour
{
    public void PanelOnOff(GameObject h)
    {
        if (h.activeSelf == true)
        {
            h.SetActive(false);
        }
        else
        {
            h.SetActive(true);
        }
    }

    public void PanelOff(GameObject j)
    {
        if (j.activeSelf == true)
        {
            j.SetActive(false);
        }
    }
}
