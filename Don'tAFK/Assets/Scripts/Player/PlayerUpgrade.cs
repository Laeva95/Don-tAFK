using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] TopUI m_TopUI;
    [SerializeField] Text m_PowerText;
    [SerializeField] Text m_SpeedText;
    [SerializeField] Text m_AreaText;
    [SerializeField] Text m_MaxHPText;
    [SerializeField] Text m_HPRegenText;
    [SerializeField] Text m_ArmorText;
    [SerializeField] Text m_GoldText;
    [SerializeField] Text m_RebirthText;
    [SerializeField] Text m_AutoText;
    [SerializeField] Text m_AllText;

    [SerializeField] Text m_PowerBtnText;
    [SerializeField] Text m_SpeedBtnText;
    [SerializeField] Text m_AreaBtnText;
    [SerializeField] Text m_MaxHPBtnText;
    [SerializeField] Text m_HPRegenBtnText;
    [SerializeField] Text m_ArmorBtnText;
    [SerializeField] Text m_GoldBtnText;
    [SerializeField] Text m_RebirthBtnText;
    [SerializeField] Text m_AutoBtnText;
    [SerializeField] Text m_AllBtnText;

    [SerializeField] Button m_PowerBtn;
    [SerializeField] Button m_SpeedBtn;
    [SerializeField] Button m_AreaBtn;
    [SerializeField] Button m_MaxHPBtn;
    [SerializeField] Button m_HPRegenBtn;
    [SerializeField] Button m_ArmorBtn;
    [SerializeField] Button m_GoldBtn;
    [SerializeField] Button m_RebirthBtn;
    [SerializeField] Button m_AutoBtn;
    [SerializeField] Button m_AllBtn;
    public int PlayerAttackPowerLevel 
    { 
        get 
        { return PlayerPrefs.GetInt("AttackPowerLevel", 0); } 
        set 
        { PlayerPrefs.SetInt("AttackPowerLevel", value); } 
    }
    public int PlayerAttackSpeedLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerAttackSpeedLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerAttackSpeedLevel", value); }
    }
    public int PlayerAttackAreaLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerAttackAreaLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerAttackAreaLevel", value); }
    }
    public int PlayerMaxHPLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerHPLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerHPLevel", value); }
    }
    public int PlayerHPRegenLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerHPRegenLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerHPRegenLevel", value); }
    }
    public int PlayerArmorLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerArmorLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerArmorLevel", value); }
    }

    public int PlayerGoldLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerGoldLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerGoldLevel", value); }
    }
    public int PlayerRebirthLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerRebirthLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerRebirthLevel", value); }
    }
    public int PlayerAutoAttackLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerAutoAttackLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerAutoAttackLevel", value); }
    }
    public int PlayerAllAttackLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerAllAttackLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerAllAttackLevel", value); }
    }

    private void Start()
    {
        UpdateText();
        PlayerStatus.Instance.PlayerStatusUpdate();
    }
    public void UpdateText()
    {
        m_PowerText.text = "Power\n" + (10 + (PlayerAttackPowerLevel * 2)).ToString();
        m_SpeedText.text = "Cooldown\n" + (0.5f - (PlayerAttackSpeedLevel * 0.03f)).ToString() + " sec";
        m_AreaText.text = "Damage Radius\n" + (0.25f + (PlayerAttackAreaLevel * 0.025f)).ToString();
        m_MaxHPText.text = "Max HP\n" + (10 + (PlayerMaxHPLevel * 2)).ToString();
        m_HPRegenText.text = "Regeneration\n" + (0 + (PlayerHPRegenLevel * 1)).ToString();
        m_ArmorText.text = "Damage Reduction\n" + (0 + (PlayerArmorLevel * 1)).ToString();
        m_GoldText.text = "Earn Gold\n" + (100 + (PlayerGoldLevel * 2)).ToString() + " %";
        m_RebirthText.text = "Earn RP\n" + (100 + (PlayerRebirthLevel * 2)).ToString() + " %";
        m_AutoText.text = "Auto Touch\n" + (2 - (PlayerAutoAttackLevel * 0.05f)).ToString() + " sec";
        m_AllText.text = "Fullscreen Attack\n" + (60 - (PlayerAllAttackLevel * 1)).ToString() + " sec";

        m_PowerBtnText.text = (25 * (1 + PlayerAttackPowerLevel)).ToString() + "\nGold";
        m_SpeedBtnText.text = (100 * (1 + PlayerAttackSpeedLevel)).ToString() + "\nGold";
        m_AreaBtnText.text = (100 * (1 + PlayerAttackAreaLevel)).ToString() + "\nGold";
        m_MaxHPBtnText.text = (50 * (1 + PlayerMaxHPLevel)).ToString() + "\nGold";
        m_HPRegenBtnText.text = (200 * (1 + PlayerHPRegenLevel)).ToString() + "\nGold";
        m_ArmorBtnText.text = (200 * (1 + PlayerArmorLevel)).ToString() + "\nGold";
        m_GoldBtnText.text = (100 * (1 + PlayerGoldLevel)).ToString() + "\nGold";
        m_RebirthBtnText.text = (100 * (1 + PlayerRebirthLevel)).ToString() + "\nGold";
        m_AutoBtnText.text = (250 * (1 + PlayerAutoAttackLevel)).ToString() + "\nGold";
        m_AllBtnText.text = (500 * (1 + PlayerAllAttackLevel)).ToString() + "\nGold";

        if (PlayerAttackSpeedLevel >= 10)
        {
            m_SpeedBtn.interactable = false;
            m_SpeedBtnText.text = "Max";
        }
        if (PlayerAttackAreaLevel >= 30)
        {
            m_AreaBtn.interactable = false;
            m_AreaBtnText.text = "Max";
        }
        if (PlayerAutoAttackLevel >= 30)
        {
            m_AutoBtn.interactable = false;
            m_AutoBtnText.text = "Max";
        }
        if (PlayerAllAttackLevel >= 40)
        {
            m_AllBtn.interactable = false;
            m_AllBtnText.text = "Max";
        }

        m_TopUI.UpdateText();
        PlayerStatus.Instance.PlayerStatusUpdate();
    }

    public void AttackPowerBtn()
    {
        if ((25 * (1 + PlayerAttackPowerLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (25 * (1 + PlayerAttackPowerLevel));
            PlayerAttackPowerLevel++;
            UpdateText();
        }
    }
    public void AttackSpeedBtn()
    {
        if ((100 * (1 + PlayerAttackSpeedLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (100 * (1 + PlayerAttackSpeedLevel));
            PlayerAttackSpeedLevel++;

            UpdateText();
        }
    }
    public void AttackAreaBtn()
    {
        if ((100 * (1 + PlayerAttackAreaLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (100 * (1 + PlayerAttackAreaLevel));
            PlayerAttackAreaLevel++;

            UpdateText();
        }
    }
    public void HPBtn()
    {
        if ((50 * (1 + PlayerMaxHPLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (50 * (1 + PlayerMaxHPLevel));
            PlayerMaxHPLevel++;
            UpdateText();
        }
    }
    public void HPRegenBtn()
    {
        if ((200 * (1 + PlayerHPRegenLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (200 * (1 + PlayerHPRegenLevel));
            PlayerHPRegenLevel++;
            UpdateText();
        }
    }
    public void ArmorBtn()
    {
        if ((200 * (1 + PlayerArmorLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (200 * (1 + PlayerArmorLevel));
            PlayerArmorLevel++;
            UpdateText();
        }
    }
    public void GoldBtn()
    {
        if ((100 * (1 + PlayerGoldLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (100 * (1 + PlayerGoldLevel));
            PlayerGoldLevel++;
            UpdateText();
        }
    }
    public void RebirthBtn()
    {
        if ((100 * (1 + PlayerRebirthLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (100 * (1 + PlayerRebirthLevel));
            PlayerRebirthLevel++;
            UpdateText();
        }
    }
    public void AutoBtn()
    {
        if ((250 * (1 + PlayerAutoAttackLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (250 * (1 + PlayerAutoAttackLevel));
            PlayerAutoAttackLevel++;

            UpdateText();
        }
    }
    public void AllBtn()
    {
        if ((500 * (1 + PlayerAllAttackLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (500 * (1 + PlayerAllAttackLevel));
            PlayerAllAttackLevel++;

            UpdateText();
        }
    }
}
