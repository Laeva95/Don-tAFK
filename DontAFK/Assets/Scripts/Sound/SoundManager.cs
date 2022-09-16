using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SOUND_NAME
{
    MONSTERATTACK = 0,
    MONSTERSPAWN = 1,
    PLAYERALLATTACK = 2,
    PLAYERATTACK = 3,
    UI = 4,
    MONSTERATTACK2 = 5,

}

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] m_Clips;
    AudioSource[] m_Audios;
    public float Volume { get; private set; }
    private static SoundManager instance;
    public static SoundManager Instance
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

        m_Audios = GetComponents<AudioSource>();

        Volume = PlayerPrefs.GetFloat("volume", 0.2f);

        for (int i = 0; i < m_Audios.Length; i++)
        {
            m_Audios[i].volume = Volume;
        }
    }
    public void SoundPlay(SOUND_NAME _NAME)
    {
        // for���� ���� ����� �ҽ� ������ ����
        for (int i = 0; i < m_Audios.Length; i++)
        {
            // ���� ����� �ҽ��� ��� ���� ��� ���� ����� �ҽ��� Ȯ��
            if (m_Audios[i].isPlaying)
            {
                if (m_Audios[i].clip == m_Clips[(int)_NAME])
                {
                    // ������ Ŭ���� ������ϰ�� ���� �� �ٽ� ���
                    m_Audios[i].Stop();
                    m_Audios[i].Play();
                    return;
                }
                continue;
            }
            // ����� �ҽ��� ��� ������ ���� ���
            // �Ű������� ���� ������ ���� ������ҽ��� Ŭ�� ����
            m_Audios[i].clip = m_Clips[(int)_NAME];

            if (m_Audios[i].clip != null)
            {
                // ����� Ŭ�� ��� �� ����
                m_Audios[i].Play();
                return;
            }
        }
    }
    public void VolumeChange(float _volume)
    {
        // ��� ����� �ҽ��� ������ �����̴� ������ ����
        for (int i = 0; i < m_Audios.Length; i++)
        {
            m_Audios[i].volume = _volume;
        }

        // ���� ������ �� ���� ����
        Volume = _volume;

        // PlayerPrefs�� float �� ����
        PlayerPrefs.SetFloat("volume", Volume);
    }
}

