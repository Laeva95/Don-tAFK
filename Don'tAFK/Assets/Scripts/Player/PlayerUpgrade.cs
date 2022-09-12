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

    [SerializeField] Text m_PowerBtnText;
    [SerializeField] Text m_SpeedBtnText;
    [SerializeField] Text m_AreaBtnText;
    [SerializeField] Text m_MaxHPBtnText;
    [SerializeField] Text m_HPRegenBtnText;
    [SerializeField] Text m_ArmorBtnText;
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

    private void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        m_PowerText.text = "Power\n" + (5 + (PlayerAttackPowerLevel * 2)).ToString();
        m_SpeedText.text = "Cooldown\n" + (0.5f - (PlayerAttackSpeedLevel * 0.1f)).ToString();
        m_AreaText.text = "Damage Radius\n" + (0.25f + (PlayerAttackAreaLevel * 0.025f)).ToString();
        m_MaxHPText.text = "Max HP\n" + (10 + (PlayerMaxHPLevel * 2)).ToString();
        m_HPRegenText.text = "Regeneration\n" + (0 + (PlayerHPRegenLevel * 1)).ToString();
        m_ArmorText.text = "Damage Reduction\n" + (0 + (PlayerArmorLevel * 1)).ToString();

        m_PowerBtnText.text = (25 * (1 + PlayerAttackPowerLevel)).ToString() + "\nGold";
        m_SpeedBtnText.text = (300 * (1 + PlayerAttackSpeedLevel)).ToString() + "\nGold";
        m_AreaBtnText.text = (100 * (1 + PlayerAttackAreaLevel)).ToString() + "\nGold";
        m_MaxHPBtnText.text = (50 * (1 + PlayerMaxHPLevel)).ToString() + "\nGold";
        m_HPRegenBtnText.text = (200 * (1 + PlayerHPRegenLevel)).ToString() + "\nGold";
        m_ArmorBtnText.text = (200 * (1 + PlayerArmorLevel)).ToString() + "\nGold";

        m_TopUI.UpdateText();
    }

    public void AttackPowerBtn()
    {
        if ((25 * (1 + PlayerAttackPowerLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (24 * (1 + PlayerAttackPowerLevel));
            PlayerAttackPowerLevel++;
            UpdateText();
        }
    }
    public void AttackSpeedBtn()
    {
        if ((300 * (1 + PlayerAttackSpeedLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (300 * (1 + PlayerAttackSpeedLevel));
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
}
