
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer card;
    [SerializeField] SpriteRenderer character;
    [SerializeField] TMP_Text nameTMP;
    [SerializeField] TMP_Text attackTMP;
    [SerializeField] TMP_Text healthTMP;
    [SerializeField] Sprite cardFront;
    [SerializeField] Sprite cardBack;

    public Item item;
    bool isFront;
    public PRS originPRS;

    private bool isLarge = false;

    public GameObject button;

    public void Setup(Item item, bool isFront)
    {
        this.item = item;
        this.isFront = isFront;
        
        if (this.isFront)
        {
            character.sprite = this.item.sprite;
            nameTMP.text = this.item.name;
            attackTMP.text = this.item.attack.ToString();
            healthTMP.text = this.item.health.ToString();
        }
        else
        {
            card.sprite = cardBack;
            nameTMP.text = "";
            attackTMP.text = "";
            healthTMP.text = "";
        }
    }

    /*
    void OnMouseOver()
    {
        if (isFront)
            CardManager.Inst.CardMouseOver(this);
        print("마우스오버");
    }

    void OnMouseExit()
    {
        if (isFront)
            CardManager.Inst.CardMouseExit(this);
        print("마우스엑시트");
    }
    
    void OnMouseDown()
    {
        if (isFront)
            CardManager.Inst.CardMouseDown();
    }

    void OnMouseUp()
    {
        if (isFront)
            CardManager.Inst.CardMouseUp();
    }
    */

    void OnMouseUpAsButton()
    {
        if (isFront && !isLarge)
        {
            CardManager.Inst.CardMouseOver(this);
            button.SetActive(true);
            isLarge = true;
        }
        else if (isFront && isLarge)
        {
            CardManager.Inst.CardMouseExit(this);
            button.SetActive(false);
            isLarge = false;
        }
    }

    public void MoveTransform(PRS prs, bool useDotween, float dotweenTime = 0)
    {
        if (useDotween)
        {
            transform.DOMove(prs.pos, dotweenTime);
            transform.DORotateQuaternion(prs.rot, dotweenTime);
            transform.DOScale(prs.scale, dotweenTime);
        }
        else
        {
            transform.position = prs.pos;
            transform.rotation = prs.rot;
            transform.localScale = prs.scale;
        }
    }
}




