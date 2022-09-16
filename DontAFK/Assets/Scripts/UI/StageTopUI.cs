using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageTopUI : MonoBehaviour
{
    [SerializeField] Text m_GoldText, m_RPText, m_StageText;

    private static StageTopUI instance;
    public static StageTopUI Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        m_GoldText.text = PlayerResource.Instance.PlayerGold.ToString() + " Gold";
        m_RPText.text = PlayerResource.Instance.PlayerRebirthPoint.ToString() + " RP";
        m_StageText.text = MonsterSpawnManager.Stage.ToString() + " Stage";
    }
}
