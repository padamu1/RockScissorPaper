using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPipetteManager : MonoBehaviour
{
    [SerializeField]
    private FlexibleColorPicker fcp;
    private bool isColorPick;
    void Start()
    {
        isColorPick = false;
        fcp = GetComponent<FlexibleColorPicker>();

        Toggle t = fcp.transform.Find("ColorPipette").GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
