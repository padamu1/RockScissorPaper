using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class Pixel : MonoBehaviour
{
    [SerializeField]
    private  Material ColorBender;
    [SerializeField]
    private Color col;


    [SerializeField]
    private FlexibleColorPicker fcp;
    [SerializeField]
    private Toggle tg;  //ColorPipette
    [SerializeField]
    private Toggle tg2; //LineDraw
    public Color Col
    {
        get { return col; }
        set { 
            col = value;
            transform.GetComponent<Image>().color = col;
            }
    }

    void Start()
    {
        transform.GetComponent<Button>().OnPointerDownAsObservable()
            .Subscribe(_ => {
                if (tg.isOn)
                {
                    fcp.SetColorNoAlpha(col);
                    tg.isOn = false;
                }
                else
                {
                    transform.GetComponent<Image>().color = ColorBender.color;
                    col = ColorBender.color;
                }
                    
        });

        transform.GetComponent<Button>().OnPointerEnterAsObservable()
            .Subscribe(_ =>
            {
                if (!Input.GetMouseButton(0)) { return; }
                if (tg2.isOn)
                {
                    transform.GetComponent<Image>().color = ColorBender.color;
                    col = ColorBender.color;
                }
            });
    }

}
