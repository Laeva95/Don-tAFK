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

    [SerializeField] PlayerRebirth m_Rebirth;
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
        Time.timeScale = 1;
        UpdateText();
    }
    public void UpdateText()
    {
        m_PowerText.text = "Power\n" + (10 + (PlayerAttackPowerLevel * 2)).ToString();
        m_SpeedText.text = "Touch Cooldown\n" + (0.5f - (PlayerAttackSpeedLevel * 0.03f)).ToString() + " sec";
        m_AreaText.text = "Damage Radius\n" + (0.25f + (PlayerAttackAreaLevel * 0.025f)).ToString();
        m_MaxHPText.text = "Max HP\n" + (20 + (PlayerMaxHPLevel * 5)).ToString();
        m_HPRegenText.text = "Regeneration\n" + (0 + (PlayerHPRegenLevel * 1)).ToString();
        m_ArmorText.text = "Damage Reduction\n" + (0 + (PlayerArmorLevel * 1)).ToString();
        m_GoldText.text = "Earn Gold\n" + (100 + (PlayerGoldLevel * 2)).ToString() + " %";
        m_RebirthText.text = "Earn RP\n" + (100 + (PlayerRebirthLevel * 2)).ToString() + " %";
        m_AutoText.text = "Auto Touch\n" + (2 - (PlayerAutoAttackLevel * 0.05f)).ToString() + " sec";
        m_AllText.text = "Fullscreen Attack\n" + (60 - (PlayerAllAttackLevel * 1)).ToString() + " sec";

        m_PowerBtnText.text = (50 * (1 + PlayerAttackPowerLevel)).ToString() + "\nGold";
        m_SpeedBtnText.text = (250 * (1 + PlayerAttackSpeedLevel)).ToString() + "\nGold";
        m_AreaBtnText.text = (500 * (1 + PlayerAttackAreaLevel)).ToString() + "\nGold";
        m_MaxHPBtnText.text = (100 * (1 + PlayerMaxHPLevel)).ToString() + "\nGold";
        m_HPRegenBtnText.text = (250 * (1 + PlayerHPRegenLevel)).ToString() + "\nGold";
        m_ArmorBtnText.text = (500 * (1 + PlayerArmorLevel)).ToString() + "\nGold";
        m_GoldBtnText.text = (200 * (1 + PlayerGoldLevel)).ToString() + "\nGold";
        m_RebirthBtnText.text = (200 * (1 + PlayerRebirthLevel)).ToString() + "\nGold";
        m_AutoBtnText.text = (250 * (1 + PlayerAutoAttackLevel)).ToString() + "\nGold";
        m_AllBtnText.text = (500 * (1 + PlayerAllAttackLevel)).ToString() + "\nGold";

        if (PlayerAttackSpeedLevel >= 10)
        {
            m_SpeedBtn.interactable = false;
            m_SpeedBtnText.text = "Max";
        }
        else
        {
            m_SpeedBtn.interactable = true;
        }
        if (PlayerAttackAreaLevel >= 30)
        {
            m_AreaBtn.interactable = false;
            m_AreaBtnText.text = "Max";
        }
        else
        {
            m_AreaBtn.interactable = true;
        }
        if (PlayerAutoAttackLevel >= 30)
        {
            m_AutoBtn.interactable = false;
            m_AutoBtnText.text = "Max";
        }
        else
        {
            m_AutoBtn.interactable = true;
        }
        if (PlayerAllAttackLevel >= 40)
        {
            m_AllBtn.interactable = false;
            m_AllBtnText.text = "Max";
        }
        else
        {
            m_AllBtn.interactable = true;
        }

        PlayerStatus.Instance.PlayerStatusUpdate();
        m_TopUI.UpdateText();
        m_Rebirth.UpdateText();
    }

    public void AttackPowerBtn()
    {
        if ((50 * (1 + PlayerAttackPowerLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (50 * (1 + PlayerAttackPowerLevel));
            PlayerAttackPowerLevel++;
            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void AttackSpeedBtn()
    {
        if ((250 * (1 + PlayerAttackSpeedLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (250 * (1 + PlayerAttackSpeedLevel));
            PlayerAttackSpeedLevel++;

            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void AttackAreaBtn()
    {
        if ((500 * (1 + PlayerAttackAreaLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (500 * (1 + PlayerAttackAreaLevel));
            PlayerAttackAreaLevel++;

            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void HPBtn()
    {
        if ((100 * (1 + PlayerMaxHPLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (100 * (1 + PlayerMaxHPLevel));
            PlayerMaxHPLevel++;
            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void HPRegenBtn()
    {
        if ((250 * (1 + PlayerHPRegenLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (250 * (1 + PlayerHPRegenLevel));
            PlayerHPRegenLevel++;
            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void ArmorBtn()
    {
        if ((500 * (1 + PlayerArmorLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (500 * (1 + PlayerArmorLevel));
            PlayerArmorLevel++;
            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void GoldBtn()
    {
        if ((200 * (1 + PlayerGoldLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (200 * (1 + PlayerGoldLevel));
            PlayerGoldLevel++;
            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void RebirthBtn()
    {
        if ((200 * (1 + PlayerRebirthLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (200 * (1 + PlayerRebirthLevel));
            PlayerRebirthLevel++;
            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void AutoBtn()
    {
        if ((250 * (1 + PlayerAutoAttackLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (250 * (1 + PlayerAutoAttackLevel));
            PlayerAutoAttackLevel++;

            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void AllBtn()
    {
        if ((500 * (1 + PlayerAllAttackLevel)) <= PlayerResource.Instance.PlayerGold)
        {
            PlayerResource.Instance.PlayerGold -= (500 * (1 + PlayerAllAttackLevel));
            PlayerAllAttackLevel++;

            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
}
