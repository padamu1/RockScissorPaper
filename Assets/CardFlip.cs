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
    Sequence mySequence1;
    Sequence mySequence2;

    private Vector3 startRotateVector = new Vector3(0, 90.1f, 0);
    private Vector3 endRotateVector = new Vector3(0, 0.01f, 0);
    private void Start()
    {
        // 애니메이션 설정
        rect = transform.GetComponent<RectTransform>();

        mySequence1 = DOTween.Sequence();
        mySequence1.Append(rect.DOLocalRotate(startRotateVector, duration));
        mySequence1.AppendCallback(CardOn);
        mySequence1.Append(rect.DOLocalRotate(endRotateVector, duration));
        mySequence1.SetAutoKill(false);
        mySequence1.Pause();

        mySequence2 = DOTween.Sequence();
        mySequence2.Append(rect.DOLocalRotate(startRotateVector, duration));
        mySequence2.AppendCallback(CardOff);
        mySequence2.Append(rect.DOLocalRotate(endRotateVector, duration));
        mySequence2.SetAutoKill(false);
        mySequence2.Pause();

        //init
        isFront = frontCard.activeSelf;
        preFlip = isFront;

        //StartCoroutine(FlippingCard());
    }

    private void CardOff()
    {
        frontCard.SetActive(false);
        backCard.SetActive(true);
    }
    private void CardOn()
    {
        frontCard.SetActive(true);
        backCard.SetActive(false);
    }
    IEnumerator FlippingCard()
    {
        while(true)
        {
        yield return null;
        if(preFlip != isFront)
            {
                preFlip = isFront;
                if (isFront) { mySequence1.Restart(); };
                if (!isFront) { mySequence2.Restart(); };
            }
        }
    }
}