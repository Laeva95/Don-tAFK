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
        // for문을 통해 오디오 소스 각각에 접근
        for (int i = 0; i < m_Audios.Length; i++)
        {
            // 현재 오디오 소스가 재생 중일 경우 다음 오디오 소스를 확인
            if (m_Audios[i].isPlaying)
            {
                if (m_Audios[i].clip == m_Clips[(int)_NAME])
                {
                    // 동일한 클립이 재생중일경우 정지 후 다시 재생
                    m_Audios[i].Stop();
                    m_Audios[i].Play();
                    return;
                }
                continue;
            }
            // 오디오 소스가 재생 중이지 않을 경우
            // 매개변수로 들어온 정보에 따라 오디오소스의 클립 변경
            m_Audios[i].clip = m_Clips[(int)_NAME];

            if (m_Audios[i].clip != null)
            {
                // 변경된 클립 재생 후 리턴
                m_Audios[i].Play();
                return;
            }
        }
    }
    public void VolumeChange(float _volume)
    {
        // 모든 오디오 소스의 볼륨을 슬라이더 값으로 설정
        for (int i = 0; i < m_Audios.Length; i++)
        {
            m_Audios[i].volume = _volume;
        }

        // 볼륨 변수에 이 값을 저장
        Volume = _volume;

        // PlayerPrefs에 float 값 저장
        PlayerPrefs.SetFloat("volume", Volume);
    }
}

