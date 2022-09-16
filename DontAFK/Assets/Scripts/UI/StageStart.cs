using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageStart : MonoBehaviour
{
    [SerializeField] Text m_BestStageText;
    public void StartStageBtn()
    {
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
        PlayerStatus.Instance.PlayerStatusUpdate();

        SceneManager.LoadScene(1);
    }
    private void Start()
    {
        BestStageUpdate();
    }

    public void BestStageUpdate()
    {
        m_BestStageText.text = "Best Stage\n" + PlayerResource.Instance.PlayerClearStage.ToString();
    }
}
