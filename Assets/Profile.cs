using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class Profile : MonoBehaviour
{

    private GameObject profileSettingPopup;
    private Button button;
    void Start()
    {
        profileSettingPopup = GameObject.Find("LobbyCanvas").transform.Find("ProfileSettingPopup").gameObject;
        button = GetComponent<Button>();

        button
            .OnClickAsObservable()
            .Subscribe(_ =>
            {
                profileSettingPopup.SetActive(true);
            });
    }

}
