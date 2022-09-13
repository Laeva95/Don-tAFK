using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // 플레이어 스테이터스
    public int PlayerAttackPower { get; private set; }
    public float PlayerAttackSpeed { get; private set; }
    public float PlayerAttackArea { get; private set; }
    public int PlayerMaxHP { get; private set; }
    public int PlayerHPRegen { get; private set; }
    public int PlayerArmor { get; private set; }
    public float PlayerGoldLevel { get; private set; }
    public float PlayerRebirthLevel { get; private set; }
    public float PlayerAutoAttackLevel { get; private set; }
    public int PlayerAllAttackLevel { get; private set; }



    private static PlayerStatus instance;
    public static PlayerStatus Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            else
            {
                return instance;
            }
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public void PlayerStatusUpdate()
    {
        PlayerUpgrade up =  FindObjectOfType<PlayerUpgrade>();

        PlayerAttackPower = 10 + (up.PlayerAttackPowerLevel * 2);
        PlayerAttackSpeed = 0.5f - (up.PlayerAttackSpeedLevel * 0.03f);
        PlayerAttackArea = 0.25f + (up.PlayerAttackAreaLevel * 0.025f);
        PlayerMaxHP = 10 + (up.PlayerMaxHPLevel * 2);
        PlayerHPRegen = 0 + (up.PlayerHPRegenLevel * 1);
        PlayerArmor = 0 + (up.PlayerArmorLevel * 1);
        PlayerGoldLevel = 1 + (up.PlayerGoldLevel * 0.02f);
        PlayerRebirthLevel = 1 + (up.PlayerRebirthLevel * 0.02f);
        PlayerAutoAttackLevel = 2 - (up.PlayerAutoAttackLevel * 0.05f);
        PlayerAllAttackLevel = 60 - (up.PlayerAllAttackLevel * 1);
    }
}
