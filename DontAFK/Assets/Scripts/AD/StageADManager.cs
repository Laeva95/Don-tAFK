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

    #region ��� ����
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

    #region ������ ����
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
        int setWidth = 900; // ����� ���� �ʺ�
        int setHeight = 1900; // ����� ���� ����

        int deviceWidth = Screen.width; // ��� �ʺ� ����
        int deviceHeight = Screen.height; // ��� ���� ����

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ� ����� ����ϱ�

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο� ����
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
        }
    }
}