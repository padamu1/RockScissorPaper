using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isFront = false;
    bool preFlip = false;
    public GameObject frontCard;
    public GameObject backCard;

    public float duration = 1.0f;

    RectTransform rect;
    Sequence mySequence;

    private void Start()
    {
        mySequence = DOTween.Sequence();
        rect = transform.GetComponent<RectTransform>();
        //StartCoroutine(FlippingCard());
        //init
        isFront = frontCard.active;
        preFlip = isFront;
    }

    IEnumerator FlippingCard()
    {
        while(true)
        {
        yield return null;
        if(preFlip != isFront)
            {
                preFlip = isFront;
                if (isFront) { FlipForward(); };
                if (!isFront) { FlipBackward(); };
            }
        }
    }

    public void FlipForward()
    {
        rect.DOLocalRotate(new Vector3(0, 90.1f, 0), duration).OnComplete(() =>
        {
            frontCard.SetActive(true);
            backCard.SetActive(false);
            rect.DOLocalRotate(new Vector3(0, 0.01f, 0), duration);
        });
    }

    public void FlipBackward()
    {
        rect.DOLocalRotate(new Vector3(0, -90.1f, 0), duration).OnComplete(() =>
        {
            backCard.SetActive(true);
            frontCard.SetActive(false);
            rect.DOLocalRotate(new Vector3(0, -0.01f, 0), duration);
        });
    }
}


/*
  mySequence.OnPlay(  );
  mySequence.Append(rect.DOLocalRotate(new Vector3(0, 90.1f, 0), duration));
        mySequence.Pause();
        backCard.SetActive(true);
        frontCard.SetActive(false);
       
        mySequence.Append(rect.DOLocalRotate(new Vector3(0, 0, 0), duration));
 */