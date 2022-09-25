using SimulFactory.Game.Event;
using SimulFactory.Manager;
using SimulFactory.Script.Util;
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
    [SerializeField] private GameObject uiFrame;
    private bool isLoginClicked = false;
    private void Awake()
    {
        Managers.GetInstance();
    }
    private void Start()
    {
        SocketManager.GetInstance().Init();
        uiFrame.gameObject.SetActive(false);
        StartCoroutine(WaitForServer());
    }
    private IEnumerator WaitForServer()
    {
        WaitForSeconds waitTime = new WaitForSeconds(1f);
        while(SocketManager.GetInstance().GetWebSocketState() != WebSocketSharp.WebSocketState.Open)
        {
            yield return waitTime;
        }
        //uiFrame.gameObject.SetActive(true);
        isLoginClicked = false;
        LoginButtonClicked();
    }
    public void LoginButtonClicked()
    {
        if (isLoginClicked) return;
        isLoginClicked = true;
        EventManager.GetInstance().StartListening((byte)Define.UNITY_EVENT.Login, LoginState);

        long userNo = 0;
        if (PlayerPrefs.HasKey(Define.PLAYERPREFS_USER_NO))
        {
            userNo = long.Parse(PlayerPrefs.GetString(Define.PLAYERPREFS_USER_NO));
        }
        C_Login.LoginC(userNo);
    }
    private void LoginState(Dictionary<string,object> message)
    {
        EventManager.GetInstance().StopListening((byte)Define.UNITY_EVENT.Login, LoginState);
        if ((bool)message["result"] == false)
        {
            isLoginClicked = false;
            return;
        }
        UserData.GetInstance().UserNo = (long)message["userNo"];
        PlayerPrefs.SetString(Define.PLAYERPREFS_USER_NO, UserData.GetInstance().UserNo.ToString());
        GameObject obj = Instantiate(Resources.Load<GameObject>("Ui/TempUi"));
        UiManager uiManager = obj.GetComponent<UiManager>();
        uiManager.Init();
        Debug.Log("Login Success");
        Managers.GetInstance().LoadScene("GameMain");
    }
    public void LoadMain()
    {
        Managers.GetInstance().LoadScene("GameMain");
    }
}
