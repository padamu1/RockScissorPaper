using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    void OnMouseUpAsButton()
    {
        CardManager.cardUIDList.Add(gameObject.transform.parent.GetInstanceID());

        foreach(int cardUID in CardManager.cardUIDList)
            Debug.Log(cardUID);
    }
}
