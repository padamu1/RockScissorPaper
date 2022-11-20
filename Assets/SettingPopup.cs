using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : MonoBehaviour
{
    static readonly string BgMusicVolKey = "BGMVol";
    static readonly string SoundFxVolKey = "SFXVol";

    float bgmVol = 0;
    float sfxVol = 0;

    public void BGMChange(float val)
    {
        bgmVol = val;
        //SoundManager.GetInstance().MusicVolume = val;
    }

    public void SFXChange(float val)
    {
        sfxVol = val;
        //SoundManager.GetInstance().SoundVolume = val;
    }

    private void OnEnable()
    {
        //bgmVol = SoundManager.GetInstance().MusicVolume;
        //sfxVol = SoundManager.GetInstance().SoundVolume;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("BGMVol", bgmVol);
        PlayerPrefs.SetFloat("SFXVol", sfxVol);
    }

    //buttons  ����������ư �г��Ӻ��� �����ʻ�������
    public void ChangeNickName()
    {

    }

    public void ChangeUserPic()
    {

    }

    public void AccountSync()
    {

    }
}
