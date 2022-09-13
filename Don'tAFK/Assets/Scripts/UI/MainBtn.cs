using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject m_UpgradeSet;
    [SerializeField]
    private GameObject m_RelicSet;
    [SerializeField]
    private GameObject m_StageSet;
    [SerializeField]
    private GameObject m_RebirthSet;
    [SerializeField]
    private GameObject m_ShopSet;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerResource.Instance.PlayerClearStage++;
        }
    }
    private void CloseUISet()
    {
        m_UpgradeSet.SetActive(false);
        m_RelicSet.SetActive(false);
        m_StageSet.SetActive(false);
        m_RebirthSet.SetActive(false);
        m_ShopSet.SetActive(false);
    }
    public void OpenUpgradeUISet()
    {
        CloseUISet();
        m_UpgradeSet.SetActive(true);
    }
    public void OpenRelicUISet()
    {
        CloseUISet();
        m_RelicSet.SetActive(true);
    }
    public void OpenStageUISet()
    {
        CloseUISet();
        m_StageSet.SetActive(true);
    }
    public void OpenRebirthUISet()
    {
        CloseUISet();
        m_RebirthSet.SetActive(true);
    }
    public void OpenShopUISet()
    {
        CloseUISet();
        m_ShopSet.SetActive(true);
    }
}
