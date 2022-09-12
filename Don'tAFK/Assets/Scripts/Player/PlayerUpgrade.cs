using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public int PlayerAttackPowerLevel 
    { 
        get 
        { return PlayerPrefs.GetInt("AttackPowerLevel", 0); } 
        set 
        { PlayerPrefs.SetInt("AttackPowerLevel", PlayerAttackPowerLevel); } 
    }
    public int PlayerAttackSpeedLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerAttackSpeedLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerAttackSpeedLevel", PlayerAttackSpeedLevel); }
    }
    public int PlayerAttackAreaLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerAttackAreaLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerAttackAreaLevel", PlayerAttackAreaLevel); }
    }
    public int PlayerMaxHPLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerHPLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerHPLevel", PlayerMaxHPLevel); }
    }
    public int PlayerHPRegenLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerHPRegenLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerHPRegenLevel", PlayerHPRegenLevel); }
    }
    public int PlayerArmorLevel
    {
        get
        { return PlayerPrefs.GetInt("PlayerArmorLevel", 0); }
        set
        { PlayerPrefs.SetInt("PlayerArmorLevel", PlayerArmorLevel); }
    }
    public void AttackPowerBtn()
    {
        if (true)
        {
            PlayerAttackPowerLevel++;
        }
    }
    public void AttackSpeedBtn()
    {
        if (true)
        {
            PlayerAttackSpeedLevel++;
        }
    }
    public void AttackAreaBtn()
    {
        if (true)
        {
            PlayerAttackAreaLevel++;
        }
    }
    public void HPBtn()
    {
        if (true)
        {
            PlayerMaxHPLevel++;
        }
    }
    public void HPRegenBtn()
    {
        if (true)
        {
            PlayerHPRegenLevel++;
        }
    }
    public void ArmorBtn()
    {
        if (true)
        {
            PlayerArmorLevel++;
        }
    }
}
