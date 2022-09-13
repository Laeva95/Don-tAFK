using UnityEngine;

public class PlayerRebirth : MonoBehaviour
{
    [SerializeField] PlayerUpgrade m_Upgrade;
    public void RebirthBtn()
    {
        if (PlayerResource.Instance.PlayerClearStage > 25)
        {
            PlayerResource.Instance.PlayerRebirthPoint += (int)(Mathf.Sqrt(PlayerResource.Instance.PlayerClearStage) 
                * PlayerStatus.Instance.PlayerRebirthLevel);

            PlayerResource.Instance.PlayerClearStage = 0;

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
        }
    }
    public void ADRebirthBtn()
    {
        if (PlayerResource.Instance.PlayerClearStage > 25)
        {
            float rebirth = PlayerResource.Instance.PlayerClearStage * 0.1f;

            PlayerResource.Instance.PlayerRebirthPoint += (int)(rebirth * rebirth * 0.5f) * 2;

            PlayerResource.Instance.PlayerClearStage = 0;

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
        }
    }
}
