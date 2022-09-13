using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRelic : MonoBehaviour
{
    [SerializeField] TopUI m_TopUI;
    [SerializeField] Text m_PowerText;
    [SerializeField] Text m_MaxHPText;
    [SerializeField] Text m_GoldText;
    [SerializeField] Text m_PowerBtnText;
    [SerializeField] Text m_MaxHPBtnText;
    [SerializeField] Text m_GoldBtnText;

    public int PlayerAttackPowerLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerAttackPowerLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerAttackPowerLevel", value); }
    }
    public int PlayerGoldLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerGoldLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerGoldLevel", value); }
    }
    public int PlayerMaxHPLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerMaxHPLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerMaxHPLevel", value); }
    }

    private void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        m_PowerText.text = "Power\n+" + (10 * (PlayerAttackPowerLevel)).ToString() + " %";
        m_MaxHPText.text = "Max HP\n+" + (10 * (PlayerMaxHPLevel)).ToString() + " %";
        m_GoldText.text = "Earn Gold\n+" + (10 * (PlayerGoldLevel)).ToString() + " %";

        m_PowerBtnText.text = (5 * (1 + PlayerAttackPowerLevel)).ToString() + "\nRP";
        m_MaxHPBtnText.text = (5 * (1 + PlayerMaxHPLevel)).ToString() + "\nRP";
        m_GoldBtnText.text = (10 * (1 + PlayerGoldLevel)).ToString() + "\nRP";

        m_TopUI.UpdateText();
        PlayerStatus.Instance.PlayerStatusUpdate();
    }

    public void AttackPowerBtn()
    {
        if ((5 * (1 + PlayerAttackPowerLevel)) <= PlayerResource.Instance.PlayerRebirthPoint)
        {
            PlayerResource.Instance.PlayerRebirthPoint -= (5 * (1 + PlayerAttackPowerLevel));
            PlayerAttackPowerLevel++;
            UpdateText();
        }
    }
    public void MaxHPBtn()
    {
        if ((5 * (1 + PlayerMaxHPLevel)) <= PlayerResource.Instance.PlayerRebirthPoint)
        {
            PlayerResource.Instance.PlayerRebirthPoint -= (5 * (1 + PlayerMaxHPLevel));
            PlayerMaxHPLevel++;

            UpdateText();
        }
    }
    public void GoldBtn()
    {
        if ((10 * (1 + PlayerGoldLevel)) <= PlayerResource.Instance.PlayerRebirthPoint)
        {
            PlayerResource.Instance.PlayerRebirthPoint -= (10 * (1 + PlayerGoldLevel));
            PlayerGoldLevel++;

            UpdateText();
        }
    }
}
