using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_GameOverSet;
    [SerializeField] GameObject m_GameOverBtnSet;
    [SerializeField] GameObject m_SoundSliderSet;
    [SerializeField] Text m_GameOverText;
    public bool IsGame { get; private set; }

    public int StageGold { get; set; }

    private static GameManager instance;
    public static GameManager Instance
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

    void Awake()
    {
        if (instance == null)
        {
            // instance가 비어있을 경우 해당 객체를 넣어줌
            instance = this;
        }
        Time.timeScale = 1;
        StageGold = 0;
        IsGame = false;
    }

    public void GameOver()
    {
        IsGame = true;
        m_GameOverSet.SetActive(true);
        m_GameOverBtnSet.SetActive(false);
        m_SoundSliderSet.SetActive(false);

        m_GameOverText.text = "You've earned " + StageGold + " Gold during this game, and you've also reached Stage " + MonsterSpawnManager.Stage;

        Time.timeScale = 0;
    }
    public void GameOverReward()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOverRewardAD()
    {


        PlayerResource.Instance.PlayerGold += StageGold;
    }
}
