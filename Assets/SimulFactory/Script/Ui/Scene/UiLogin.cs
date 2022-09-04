using SimulFactory.Game;
using SimulFactory.Manager;
using SimulFactory.WebSocket;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiLogin : MonoBehaviour
{
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField nameInput;
    private void Awake()
    {
        Managers.GetInstance();
    }
    private void Start()
    {
        StartCoroutine(WaitForServer());
    }
    private IEnumerator WaitForServer()
    {
        WaitForSeconds waitTime = new WaitForSeconds(1f);
        while(SocketManager.GetInstance().GetWebSocketState() != WebSocketSharp.WebSocketState.Open)
        {
            yield return waitTime;
        }
    }
    public void LoginButtonClicked()
    {
        if(idInput.text.Equals(string.Empty) || nameInput.text.Equals(string.Empty))
        {
            return;
        }
        C_Login.LoginC(idInput.text,nameInput.text);
    }
}
