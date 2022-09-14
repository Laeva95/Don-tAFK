using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField] Transform m_Player;
    StageBuilder m_StageBuilder;
    public static int Stage { get; private set; }
    public static int m_MonsterCount;

    private void Awake()
    {
        m_StageBuilder = new StageBuilder();
        m_MonsterCount = 0;
        Stage = 0;

        StartCoroutine(MonsterSpawn());
    }

    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            if (PlayerResource.Instance.PlayerClearStage < Stage)
            {
                PlayerResource.Instance.PlayerClearStage = Stage;
            }

            Stage += PlayerStatus.Instance.PlayerStageCountLevel;

            StageTopUI.Instance.UpdateText();

            yield return new WaitForSeconds(0.5f);

            m_StageBuilder.StageBuild(Stage);

            if (m_StageBuilder.m_StageInfo != null)
            {
                for (int i = 0; i < m_StageBuilder.m_StageInfo.num.Length; i++)
                {
                    MonsterGenerate(m_StageBuilder.m_StageInfo.num[i], m_StageBuilder.m_StageInfo.count[i]);
                    yield return null;
                }
            }
            else
            {
                for (int i = 0; i < (15 + Stage*0.02f); i++)
                {
                    int ran = Random.Range(0, 4);
                    MonsterGenerate(ran, 1);
                    yield return null;
                }
            }
            SoundManager.Instance.SoundPlay(SOUND_NAME.MONSTERSPAWN);
            while (m_MonsterCount > 0)
            {
                yield return null;
            }
        }
    }

    private void MonsterGenerate(int _monsterNum, int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            // 랜덤한 방향을 설정
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector3 dir = new Vector3(x, y, 0).normalized;

            float distance = Random.Range(2f, 2.7f);

            // 플레이어 위치에서 일정 거리 떨어진 위치에 몬스터 생성
            GameObject obj = ObjectPoolingManager.Instance.GetQueue(_monsterNum);
            obj.transform.position = m_Player.position + dir * distance;
        }
    }
}
