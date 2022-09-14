using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void GetGoldAD()
    {
        PlayerResource.Instance.PlayerGold += 5000;
        SoundManager.Instance.SoundPlay(SOUND_NAME.UI);
    }
}
