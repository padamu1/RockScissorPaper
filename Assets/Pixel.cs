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
    public Color Col
    {
        get { return col; }
    }

    void Start()
    {
        transform.GetComponent<Button>().OnPointerDownAsObservable()
            .Subscribe(_ => {
                transform.GetComponent<Image>().color = ColorBender.color;
                col = ColorBender.color;
        });
    }

}
