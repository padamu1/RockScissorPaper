using SimulFactory.Game.Event;
using SimulFactory.Manager;
using SimulFactory.System.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
    static readonly string BgMusicVolKey = "BGMVol";
    static readonly string SoundFxVolKey = "SFXVol";

    float bgmVol = 0;
    float sfxVol = 0;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Slider soundSlider;

    public void BGMChange(float val)
    {
        bgmVol = val;
        AudioSourceManager.GetInstance().MusicVolume = val;
    }

    public void SFXChange(float val)
    {
        sfxVol = val;
        AudioSourceManager.GetInstance().SoundVolume = val;
    }

    private void OnEnable()
    {
        bgmVol = AudioSourceManager.GetInstance().MusicVolume;
        sfxVol = AudioSourceManager.GetInstance().SoundVolume;
        musicSlider.value = bgmVol;
        soundSlider.value = sfxVol;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("BGMVol", bgmVol);
        PlayerPrefs.SetFloat("SFXVol", sfxVol);
        PlayerPrefs.Save();
    }

    //buttons  ����������ư �г��Ӻ��� �����ʻ�������

    public void ChangeUserNamePopup()
    {
        PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
        popupInfo.Type = Define.POPUP_TYPE.InputPopup;
        popupInfo.Title = "�г��� ����";
        popupInfo.WarningText = "Ư������ ������ ���� ��Ģ ��¼��";    // ���� �ʿ�
        popupInfo.NoButtonText = "���";
        popupInfo.InputAction = C_UserName.UserNameC;
        popupInfo.Top = true;
        popupInfo.Block = true;
        PopupManager.GetInstance().CreatePopup(popupInfo);
    }

    [System.Obsolete]
    public void ChangeUserPic()
    {
        transform.parent.parent.FindChild("CustomizeUI").gameObject.SetActive(true);
    }

    public void AccountSync()
    {

    }
}
