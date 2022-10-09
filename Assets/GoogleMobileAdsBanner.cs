using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;

public class GoogleMobileAdsBanner: MonoBehaviour
{
    private InterstitialAd interstitial;

    private void Start()
    {
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
                string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
                string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        // 광고를 닫으면 게임 다시 시작하기.
        SceneManager.LoadScene("PlayScene");
    }

    private void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void RetryGamePlay()
    {
        // RequestInterstitial();
        GameOver();

    }
}
