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

    //buttons  계정연동버튼 닉네임변경 프로필사진변경

    public void ChangeUserNamePopup()
    {
        PopupManager.PopupInfo popupInfo = PopupManager.GetInstance().GetPopupInfo();
        popupInfo.Type = Define.POPUP_TYPE.InputPopup;
        popupInfo.Title = "닉네임 변경";
        popupInfo.WarningText = "특수문자 제외한 대충 규칙 어쩌구";    // 수정 필요
        popupInfo.NoButtonText = "취소";
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
