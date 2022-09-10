using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageStart : MonoBehaviour
{
    public void StartStageBtn()
    {
        SceneManager.LoadScene(2);
    }
}
