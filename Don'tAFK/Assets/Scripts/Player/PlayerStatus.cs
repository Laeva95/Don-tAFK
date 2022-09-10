using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // 플레이어 스테이터스
    public int PlayerAttackPower { get; private set; }
    public float PlayerAttackSpeed { get; private set; }
    public float PlayerAttackArea { get; private set; }
    public int PlayerHP { get; private set; }
    public int PlayerHPRegen { get; private set; }
    public int PlayerArmor { get; private set; }


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
        PlayerUpgrade up = new PlayerUpgrade();

        PlayerAttackPower = 5 + up.PlayerAttackPowerLevel;
        PlayerAttackSpeed = 0.5f - (up.PlayerAttackSpeedLevel * 0.1f);
        PlayerAttackArea = 1f + (up.PlayerAttackAreaLevel * 0.05f);
        PlayerHP = 100 + (up.PlayerHPLevel * 5);
        PlayerHPRegen = 0 + (up.PlayerHPRegenLevel * 1);
        PlayerArmor = 0 + (up.PlayerArmorLevel * 1);
    }
}
