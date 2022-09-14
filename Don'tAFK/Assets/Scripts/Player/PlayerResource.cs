using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResource : MonoBehaviour
{
    public int PlayerGold
    {
        get
        { return PlayerPrefs.GetInt("PlayerGold", 0); }
        set
        { PlayerPrefs.SetInt("PlayerGold", value); }
    }
    public int PlayerRebirthPoint
    {
        get
        { return PlayerPrefs.GetInt("PlayerRebirthPoint", 0); }
        set
        { PlayerPrefs.SetInt("PlayerRebirthPoint", value); }
    }
    public int PlayerClearStage
    {
        get
        { return PlayerPrefs.GetInt("PlayerClearStage", 0); }
        set
        { PlayerPrefs.SetInt("PlayerClearStage", value); }
    }

    public float GoldADCool
    {
        get
        { return PlayerPrefs.GetFloat("GoldADCool", 0); }
        set
        { PlayerPrefs.SetFloat("GoldADCool", value); }
    }

    private static PlayerResource instance;
    public static PlayerResource Instance
    {
        get
        {
            if (instance == null)
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
}
