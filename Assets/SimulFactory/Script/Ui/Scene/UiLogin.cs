using SimulFactory.Game;
using SimulFactory.Manager;
using SimulFactory.WebSocket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLogin : MonoBehaviour
{
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
        LoginToServer();
    }
    private void LoginToServer()
    {
        C_Login.LoginC();
    }
}
