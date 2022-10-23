using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;

public class GoogleMobileAdsBanner: MonoBehaviour
{
    static GoogleMobileAdsBanner AD;
    static GoogleMobileAdsBanner GetAd() { Init();  return AD; }
    private BannerView bannerView;

    public void Start()
    {
        //AD = this;
        Init();
        AD.RequestBanner();
    }

    static void Init()
    {

        GameObject go = GameObject.Find("@GoogleMobileAdsBanner");
        if(go == null)
        {
            go = new GameObject { name = "@GoogleMobileAdsBanner" };
            go.AddComponent<GoogleMobileAdsBanner>();
        }

        DontDestroyOnLoad(go);
        AD = go.GetComponent<GoogleMobileAdsBanner>();
    }


    private void RequestBanner()
    {

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif


        AdSize adaptiveSize =
                AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);


        this.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);

        // Called when an ad request has successfully loaded.
        AD.bannerView.OnAdLoaded += AD.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        AD.bannerView.OnAdFailedToLoad += AD.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        AD.bannerView.OnAdOpening += AD.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        AD.bannerView.OnAdClosed += AD.HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        AD.bannerView.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.LoadAdError.GetMessage());
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }



    public void OnDisable2()

    {
            AD.bannerView.Hide();
    }

    
    public void OnEnable2()   //아마 사용 안할 메서드

    {
        //AdRequest request = new AdRequest.Builder().Build();
        //AD.bannerView.LoadAd(request);
        if (GameObject.Find("ADAPTIVE(Clone)") == null)
            AD.bannerView.Show();
    }

    

}
