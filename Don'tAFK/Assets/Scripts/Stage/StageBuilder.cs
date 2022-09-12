using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBuilder
{
    public StageInfo m_StageInfo;
    public void StageBuild(int _stage)
    {
        m_StageInfo = LoadStage(_stage);
    }

    public StageInfo LoadStage(int _stage)
    {
        // �ε��� �������� ���� �̸�
        Debug.Log($"Load Stage : Stage/{GetFileName(_stage)}");

        //1. ���ҽ� ���Ͽ��� �ؽ�Ʈ�� �о�´�.
        TextAsset textAsset = Resources.Load<TextAsset>($"Stage/{GetFileName(_stage)}");
        if (textAsset != null)
        {
            //2. JSON ���ڿ��� ��ü(StageInfo)�� ��ȯ�Ѵ�.
            StageInfo stageInfo = JsonUtility.FromJson<StageInfo>(textAsset.text);

            return stageInfo;
        }
        return null;
    }
     string GetFileName(int nStage)
    {
        return string.Format("stage_{0:D4}", nStage);
    }
}
