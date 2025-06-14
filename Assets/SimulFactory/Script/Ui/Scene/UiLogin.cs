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
        AudioSourceManager.GetInstance();
    }
    private void Start()
    {
        // 최초 한번만 생성
        if(UserData.GetInstance().IsFirstActive)
        {
            // GameUi 로드
            GameObject gameUi = Instantiate(Resources.Load<GameObject>("Ui/GameUi"));
            UiManager uiManager = gameUi.GetComponent<UiManager>();
            BattleManager.GetInstance();
            // HelperMenu 로드
            Instantiate(Resources.Load<GameObject>("Ui/MainCanvas/HelperMenu"), uiManager.gameObject.transform, false);
            UserData.GetInstance().IsFirstActive = false;
        }
    }
    private void OnEnable()
    {
        //AudioSourceManager.GetInstance().PlayMusic("bgm_login");
        SocketManager.GetInstance().Init(LoginToServer);
        uiFrame.gameObject.SetActive(false);
    }
    private void LoginToServer()
    {
        //uiFrame.gameObject.SetActive(true);
        isLoginClicked = false;
        LoginButtonClicked();
    }
    public void LoginButtonClicked()
    {
        if (isLoginClicked) return;
        isLoginClicked = true;
        EventManager.GetInstance().StartListening(Define.UNITY_EVENT.Login, LoginState);

        long userNo = 0;
        if (PlayerPrefs.HasKey(Define.PLAYERPREFS_USER_NO))
        {
            userNo = long.Parse(PlayerPrefs.GetString(Define.PLAYERPREFS_USER_NO));
        }
        C_Login.LoginC(userNo);
    }
    private void LoginState(Dictionary<string,object> message)
    {
        EventManager.GetInstance().StopListening(Define.UNITY_EVENT.Login, LoginState);
        if ((bool)message["result"] == false)
        {
            isLoginClicked = false;
            return;
        }
        UiManager.GetInstance().gameObject.SetActive(true);
        UserData.GetInstance().ResetUserData();
        UserData.GetInstance().UserNo = (long)message["userNo"];
        PlayerPrefs.SetString(Define.PLAYERPREFS_USER_NO, UserData.GetInstance().UserNo.ToString());
        UiManager.GetInstance().Init();
        Debug.Log("Login Success");
        Managers.GetInstance().LoadScene("GameMain");
    }
    public void ResetBUttonClicked()
    {
        PlayerPrefs.DeleteAll();
        SocketManager.GetInstance().Disconnect();
    }
    public void LoadMain()
    {
        Managers.GetInstance().LoadScene("GameMain");
    }
}
