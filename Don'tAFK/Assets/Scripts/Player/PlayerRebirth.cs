using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRebirth : MonoBehaviour
{
    public void RebirthBtn()
    {
        if (PlayerResource.Instance.PlayerClearStage > 25)
        {
            float rebirth = PlayerResource.Instance.PlayerClearStage * 0.1f;

            PlayerResource.Instance.PlayerRebirthPoint += (int)(rebirth * rebirth * 0.5f);

            PlayerResource.Instance.PlayerClearStage = 0;
        }
    }
    public void ADRebirthBtn()
    {
        if (PlayerResource.Instance.PlayerClearStage > 25)
        {
            float rebirth = PlayerResource.Instance.PlayerClearStage * 0.1f;

            PlayerResource.Instance.PlayerRebirthPoint += (int)(rebirth * rebirth * 0.5f) * 2;

            PlayerResource.Instance.PlayerClearStage = 0;
        }
    }
}
