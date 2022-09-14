using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBtn : MonoBehaviour
{
    [SerializeField] GameObject m_GameOverSet;
    [SerializeField] GameObject m_SoundSliderSet;

    public void OnGameOver()
    {
        if (m_GameOverSet.activeSelf)
        {
            m_GameOverSet.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            m_SoundSliderSet.SetActive(false);
            m_GameOverSet.SetActive(true);
            Time.timeScale = 0;
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.IsGame)
        {
            OnGameOver();
        }
    }

    public void GameOverYes()
    {
        GameManager.Instance.GameOver();
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
    public void GameOverNo()
    {
        OnGameOver();
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
}
