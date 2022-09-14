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
    [SerializeField] Text m_StageCountText;
    [SerializeField] Text m_PowerBtnText;
    [SerializeField] Text m_MaxHPBtnText;
    [SerializeField] Text m_GoldBtnText;
    [SerializeField] Text m_StageCountBtnText;

    public int PlayerAttackPowerLevel
    {
        get
        { return PlayerPrefs.GetInt("RelicAttackPowerLevel", 0); }
        set
        { PlayerPrefs.SetInt("RelicAttackPowerLevel", value); }
    }
    public int PlayerGoldLevel
    {
        get
        { return PlayerPrefs.GetInt("RelicGoldLevel", 0); }
        set
        { PlayerPrefs.SetInt("RelicGoldLevel", value); }
    }
    public int PlayerMaxHPLevel
    {
        get
        { return PlayerPrefs.GetInt("RelicMaxHPLevel", 0); }
        set
        { PlayerPrefs.SetInt("RelicMaxHPLevel", value); }
    }
    public int PlayerStageCount
    {
        get
        { return PlayerPrefs.GetInt("RelicStageCount", 1); }
        set
        { PlayerPrefs.SetInt("RelicStageCount", value); }
    }

    private void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        m_PowerText.text = "Power\n+" + (20 * (PlayerAttackPowerLevel)).ToString() + " %";
        m_MaxHPText.text = "Max HP\n+" + (20 * (PlayerMaxHPLevel)).ToString() + " %";
        m_GoldText.text = "Earn Gold\n+" + (10 * (PlayerGoldLevel)).ToString() + " %";
        m_StageCountText.text = "Stage Count\n+" + PlayerStageCount.ToString();

        m_PowerBtnText.text = (5 * (1 + PlayerAttackPowerLevel)).ToString() + "\nRP";
        m_MaxHPBtnText.text = (5 * (1 + PlayerMaxHPLevel)).ToString() + "\nRP";
        m_GoldBtnText.text = (10 * (1 + PlayerGoldLevel)).ToString() + "\nRP";
        m_StageCountBtnText.text = (100 * (PlayerStageCount)).ToString() + "\nRP";

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
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void MaxHPBtn()
    {
        if ((5 * (1 + PlayerMaxHPLevel)) <= PlayerResource.Instance.PlayerRebirthPoint)
        {
            PlayerResource.Instance.PlayerRebirthPoint -= (5 * (1 + PlayerMaxHPLevel));
            PlayerMaxHPLevel++;

            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void GoldBtn()
    {
        if ((10 * (1 + PlayerGoldLevel)) <= PlayerResource.Instance.PlayerRebirthPoint)
        {
            PlayerResource.Instance.PlayerRebirthPoint -= (10 * (1 + PlayerGoldLevel));
            PlayerGoldLevel++;

            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void StageCountBtn()
    {
        if ((100 * (PlayerStageCount)) <= PlayerResource.Instance.PlayerRebirthPoint)
        {
            PlayerResource.Instance.PlayerRebirthPoint -= (100 * (PlayerStageCount));
            PlayerStageCount++;

            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
}
