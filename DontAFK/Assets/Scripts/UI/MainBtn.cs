using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject m_UpgradeSet;
    [SerializeField]
    private GameObject m_RelicSet;
    [SerializeField]
    private GameObject m_StageSet;
    [SerializeField]
    private GameObject m_RebirthSet;
    [SerializeField]
    private GameObject m_ShopSet;
    [SerializeField]
    private GameObject m_SoundSliderSet;
    [SerializeField]
    private Text m_GoldADText;
    [SerializeField]
    private Button m_GoldADBtn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (PlayerResource.Instance.GoldADCool > 0)
        {
            m_GoldADText.text = $"{PlayerResource.Instance.GoldADCool:0.00}\nsec";
            m_GoldADBtn.interactable = false;
        }
        else
        {
            m_GoldADText.text = $"Rewarded\nAD";
            m_GoldADBtn.interactable = true;
        }
    }
    private void CloseUISet()
    {
        m_UpgradeSet.SetActive(false);
        m_RelicSet.SetActive(false);
        m_StageSet.SetActive(false);
        m_RebirthSet.SetActive(false);
        m_ShopSet.SetActive(false);
        m_SoundSliderSet.SetActive(false);
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void OpenUpgradeUISet()
    {
        CloseUISet();
        m_UpgradeSet.SetActive(true);
    }
    public void OpenRelicUISet()
    {
        CloseUISet();
        m_RelicSet.SetActive(true);
    }
    public void OpenStageUISet()
    {
        CloseUISet();
        m_StageSet.SetActive(true);
    }
    public void OpenRebirthUISet()
    {
        CloseUISet();
        m_RebirthSet.SetActive(true);
    }
    public void OpenShopUISet()
    {
        CloseUISet();
        m_ShopSet.SetActive(true);
    }
}
