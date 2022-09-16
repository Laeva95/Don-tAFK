using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSoundSlide : MonoBehaviour
{
    [SerializeField] Slider m_SoundSlide;
    [SerializeField] GameObject m_SoundSliderSet;
    [SerializeField] GameObject m_GameOverSet;
    void Start()
    {
        m_SoundSlide.value = PlayerPrefs.GetFloat("volume", 0.2f);
    }


    public void VolumeChange()
    {
        SoundManager.Instance.VolumeChange(m_SoundSlide.value);
    }

    public void OnSoundSlider()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.IsGame)
            {
                return;
            }
        }
        if (m_SoundSliderSet.activeSelf)
        {
            m_SoundSliderSet.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            m_GameOverSet.SetActive(false);
            m_SoundSliderSet.SetActive(true);
            Time.timeScale = 0;
        }
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
}
