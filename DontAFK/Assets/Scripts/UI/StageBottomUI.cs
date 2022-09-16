using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageBottomUI : MonoBehaviour
{
    [SerializeField] Text m_PowerText, m_SpeedText, m_AreaText, m_MaxHPText, m_RegenText, m_ArmorText;


    private void Start()
    {
        UpdateText();
    }

    void UpdateText()
    {
        m_PowerText.text = "Power: " + PlayerStatus.Instance.PlayerAttackPower;
        m_SpeedText.text = "Touch Cooldown: " + PlayerStatus.Instance.PlayerAttackSpeed;
        m_AreaText.text = "Damage Radius: " + PlayerStatus.Instance.PlayerAttackArea;
        m_MaxHPText.text = "Max HP: " + PlayerStatus.Instance.PlayerMaxHP;
        m_RegenText.text = "Regeneration: " + PlayerStatus.Instance.PlayerHPRegen;
        m_ArmorText.text = "Damage Reduction: " + PlayerStatus.Instance.PlayerArmor;
    }
}
