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
            Stage++;

            yield return new WaitForSeconds(1f);

            m_StageBuilder.StageBuild(Stage);

            for (int i = 0; i < m_StageBuilder.m_StageInfo.num.Length; i++)
            {
                MonsterGenerate(m_StageBuilder.m_StageInfo.num[i], m_StageBuilder.m_StageInfo.count[i]);
                yield return null;
            }

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
            // ������ ������ ����
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector3 dir = new Vector3(x, y, 0).normalized;

            float distance = Random.Range(2.5f, 3f);

            // �÷��̾� ��ġ���� ���� �Ÿ� ������ ��ġ�� ���� ����
            GameObject obj = ObjectPoolingManager.Instance.GetQueue(_monsterNum);
            obj.transform.position = m_Player.position + dir * distance;
        }
    }
}
