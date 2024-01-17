using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
 
public class BannerAd : MonoBehaviour
{
    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;

    BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

    private void Start()
    {
#if UNITY_IOS
        adUnitId = iosAdUnitId;
#elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
#endif
        // Unity Ads'i başlat
        Advertisement.Initialize("adUnitId", false);

        // Banner reklamı yükle
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER); // Bannerın konumunu ayarlayabilirsiniz
        Advertisement.Banner.SetPosition(bannerPosition);
        Advertisement.Banner.Show(adUnitId);
    }
}