using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class MainADManager : MonoBehaviour
{
    [SerializeField] Button m_GoldADBtn, m_RebirthADBtn;
    [SerializeField] bool m_IsTestMode;
    [SerializeField] PlayerRebirth m_PlayerRebirth;

    private void Start()
    {
        var requestConfiguration = new RequestConfiguration
            .Builder()
            .SetTestDeviceIds(new List<string>() { "803CCBB787F948F3" })
            .build();

        MobileAds.SetRequestConfiguration(requestConfiguration);

        LoadBannerAd();
        LoadRewardAdGold();
        LoadRewardAdRebirth();

        SetResolution();
    }
    void Update()
    {
        if (PlayerResource.Instance.PlayerClearStage >= 25 && rewardAd01.IsLoaded())
        {
            m_RebirthADBtn.interactable = true;
        }
        else
        {
            m_RebirthADBtn.interactable = false;
        }

        if (PlayerResource.Instance.GoldADCool <= 0 && rewardAd00.IsLoaded())
        {
            m_GoldADBtn.interactable = true;
        }
        else
        {
            m_GoldADBtn.interactable = false;
        }
    }

    AdRequest GetAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    const string bannerTestID = "ca-app-pub-3940256099942544/6300978111";
    const string bannerID = "ca-app-pub-5523498364041698/6566770860";
    BannerView bannerAd;

    void LoadBannerAd()
    {
        bannerAd = new BannerView(m_IsTestMode ? bannerTestID : bannerID,
            AdSize.SmartBanner, AdPosition.Bottom);
        bannerAd.LoadAd(GetAdRequest());
    }



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
            PlayerResource.Instance.PlayerGold += 5000;
            PlayerResource.Instance.GoldADCool += 600f;
            m_PlayerRebirth.m_Upgrade.UpdateText();
        };
    }
    public void ShowRewardAdGold()
    {
        rewardAd00.Show();
        LoadRewardAdGold();
    }


    RewardedAd rewardAd01;
    void LoadRewardAdRebirth()
    {
        rewardAd01 = new RewardedAd(m_IsTestMode ? rewardTestID : rewardID);
        rewardAd01.LoadAd(GetAdRequest());
        rewardAd01.OnUserEarnedReward += (sender, e) =>
        {
             m_PlayerRebirth.ADRebirthBtn();
        };
    }

    public void ShowRewardAdRebirth()
    {
        rewardAd01.Show();
        LoadRewardAdRebirth();
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
