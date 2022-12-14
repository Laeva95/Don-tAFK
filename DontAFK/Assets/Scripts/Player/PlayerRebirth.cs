using UnityEngine;
using UnityEngine.UI;

public class PlayerRebirth : MonoBehaviour
{
    public PlayerUpgrade m_Upgrade;
    [SerializeField] StageStart m_Start;
    [SerializeField] Text m_RebirthPointText;

    private void Start()
    {
        UpdateText();
        Application.targetFrameRate = 60;
    }
    public void RebirthBtn()
    {
        if (PlayerResource.Instance.PlayerClearStage >= 25)
        {
            PlayerResource.Instance.PlayerRebirthPoint += Mathf.CeilToInt((10 + Mathf.Pow(PlayerResource.Instance.PlayerClearStage * 0.1f, 1.4f))
                * PlayerStatus.Instance.PlayerRebirthLevel);

            PlayerResource.Instance.PlayerClearStage = 0;
            PlayerResource.Instance.PlayerGold = 0;

            m_Upgrade.PlayerAllAttackLevel = 0;
            m_Upgrade.PlayerArmorLevel = 0;
            m_Upgrade.PlayerAttackAreaLevel = 0;
            m_Upgrade.PlayerAttackPowerLevel = 0;
            m_Upgrade.PlayerAttackSpeedLevel = 0;
            m_Upgrade.PlayerAutoAttackLevel = 0;
            m_Upgrade.PlayerGoldLevel = 0;
            m_Upgrade.PlayerHPRegenLevel = 0;
            m_Upgrade.PlayerMaxHPLevel = 0;
            m_Upgrade.PlayerRebirthLevel = 0;

            m_Upgrade.UpdateText();
            m_Start.BestStageUpdate();
            UpdateText();
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void ADRebirthBtn()
    {
        PlayerResource.Instance.PlayerRebirthPoint += Mathf.CeilToInt((10 + Mathf.Pow(PlayerResource.Instance.PlayerClearStage * 0.1f, 1.4f))
                * PlayerStatus.Instance.PlayerRebirthLevel) * 2;

        PlayerResource.Instance.PlayerClearStage = 0;
        PlayerResource.Instance.PlayerGold = 0;

        m_Upgrade.PlayerAllAttackLevel = 0;
        m_Upgrade.PlayerArmorLevel = 0;
        m_Upgrade.PlayerAttackAreaLevel = 0;
        m_Upgrade.PlayerAttackPowerLevel = 0;
        m_Upgrade.PlayerAttackSpeedLevel = 0;
        m_Upgrade.PlayerAutoAttackLevel = 0;
        m_Upgrade.PlayerGoldLevel = 0;
        m_Upgrade.PlayerHPRegenLevel = 0;
        m_Upgrade.PlayerMaxHPLevel = 0;
        m_Upgrade.PlayerRebirthLevel = 0;

        m_Upgrade.UpdateText();
        m_Start.BestStageUpdate();
        UpdateText();
    }

    public void UpdateText()
    {
        m_RebirthPointText.text = "Expected Gain\n" + Mathf.CeilToInt((10 + Mathf.Pow(PlayerResource.Instance.PlayerClearStage * 0.1f, 1.4f))
                * PlayerStatus.Instance.PlayerRebirthLevel) + " RP";
    }
}
