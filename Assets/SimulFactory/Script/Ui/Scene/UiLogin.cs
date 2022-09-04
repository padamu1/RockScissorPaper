using SimulFactory.Game;
using SimulFactory.Manager;
using SimulFactory.System.Common;
using SimulFactory.WebSocket;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiLogin : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private TMP_InputField nameInput;
    private bool isLoginClicked = false;
    private void Awake()
    {
        Managers.GetInstance();
    }
    private void Start()
    {
        uiPanel.gameObject.SetActive(false);
        StartCoroutine(WaitForServer());
    }
    private IEnumerator WaitForServer()
    {
        WaitForSeconds waitTime = new WaitForSeconds(1f);
        while(SocketManager.GetInstance().GetWebSocketState() != WebSocketSharp.WebSocketState.Open)
        {
            yield return waitTime;
        }
        uiPanel.gameObject.SetActive(true);
        isLoginClicked = false;
    }
    public void LoginButtonClicked()
    {
        if (isLoginClicked) return;
        isLoginClicked = true;
        if (idInput.text.Equals(string.Empty) || nameInput.text.Equals(string.Empty))
        {
            return;
        }
        EventManager.GetInstance().StartListening((byte)Define.UNITY_EVENT.Login, LoginState);
        C_Login.LoginC(idInput.text,nameInput.text);
    }
    private void LoginState(Dictionary<string,object> message)
    {
        EventManager.GetInstance().StopListening((byte)Define.UNITY_EVENT.Login, LoginState);
        if ((bool)message["result"])
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            isLoginClicked = false;
        }
    }
}
