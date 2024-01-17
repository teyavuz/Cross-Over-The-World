using System;
using UnityEngine;
using UnityEngine.Advertisements;
 
public class AdInitializer : MonoBehaviour,IUnityAdsInitializationListener
{
    public bool TestMode = true;

    public string Android_ID = "";
    public string IOS_ID = "";

    string gameId;

    private void Awake()
    {
        InitializeAds();
    }


    void InitializeAds()
    {
#if UNITY_IOS
        gameId = IOS_ID;
#elif UNITY_ANDROID
        gameId = Android_ID;
#elif UNITY_EDITOR
        gameId = Android_ID;
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId,TestMode,this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ad initialized!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("failed");
    }
}