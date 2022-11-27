using SimulFactory.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FriendRequestInput : MonoBehaviour
{
    public TMP_InputField inputField;
    private string userName = null;

    public void ButtonClicked()
    {
        userName = inputField.GetComponent<TMP_InputField>().text;
        UiManager.GetInstance().FriendRequestButtonClicked(userName);
        Debug.Log("send userName : " + userName);
    }
}
