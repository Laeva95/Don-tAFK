using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class StageADManager : MonoBehaviour
{
    [SerializeField] Button m_ADBtn00;
    [SerializeField] bool m_IsTestMode;

    private void Start()
    {
        var requestConfiguration = new RequestConfiguration
            .Builder()
            .build();

        MobileAds.SetRequestConfiguration(requestConfiguration);

        LoadBannerAd();
        LoadRewardAdGold();

        SetResolution();

        StartCoroutine(LoadCheck());
    }
    IEnumerator LoadCheck()
    {
        while (!rewardAd00.IsLoaded())
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }
        m_ADBtn00.interactable = true;
    }
    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    #region 배너 광고
    const string bannerTestID = "ca-app-pub-3940256099942544/6300978111";
    const string bannerID = "ca-app-pub-5523498364041698/6566770860";
    BannerView bannerAd;

    void LoadBannerAd()
    {
        bannerAd = new BannerView(m_IsTestMode ? bannerTestID : bannerID,
            AdSize.SmartBanner, AdPosition.Bottom);
        bannerAd.LoadAd(GetAdRequest());
    }
    #endregion

    #region 리워드 광고
    const string rewardTestID = "ca-app-pub-3940256099942544/5224354917";
    const string rewardID = "ca-app-pub-5523498364041698/5392741259";
    RewardedAd rewardAd00;

    void LoadRewardAdGold()
    {
        rewardAd00 = new RewardedAd(m_IsTestMode ? rewardTestID : rewardID);
        rewardAd00.LoadAd(GetAdRequest());
        rewardAd00.OnUserEarnedReward += (sender, e) =>
        {
            GameManager.Instance.GameOverRewardAD();
            m_ADBtn00.interactable = false;
        };
    }
    public void ShowRewardAdGold()
    {
        rewardAd00.Show();
        LoadRewardAdGold();
    }
    #endregion

    public void SetResolution()
    {
        int setWidth = 900; // 사용자 설정 너비
        int setHeight = 1900; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }
}