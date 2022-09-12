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
        // 로딩된 스테이지 파일 이름
        Debug.Log($"Load Stage : Stage/{GetFileName(_stage)}");

        //1. 리소스 파일에서 텍스트를 읽어온다.
        TextAsset textAsset = Resources.Load<TextAsset>($"Stage/{GetFileName(_stage)}");
        if (textAsset != null)
        {
            //2. JSON 문자열을 객체(StageInfo)로 변환한다.
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
