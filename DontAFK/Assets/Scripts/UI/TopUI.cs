using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopUI : MonoBehaviour
{
    [SerializeField] Text m_GoldText;
    [SerializeField] Text m_RebirthPointText;
    [SerializeField] Text m_ClearStageText;


    public void UpdateText()
    {
        m_GoldText.text = PlayerResource.Instance.PlayerGold.ToString() + " Gold";
        m_RebirthPointText.text = PlayerResource.Instance.PlayerRebirthPoint.ToString() + " RP";
        m_ClearStageText.text = PlayerResource.Instance.PlayerClearStage.ToString() + " Stage";

    }

}
