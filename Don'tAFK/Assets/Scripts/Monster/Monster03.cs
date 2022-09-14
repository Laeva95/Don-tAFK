using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster03 : RangeMonster
{
    protected override void OnEnable()
    {
        m_MonsterMaxHP = 3 + (int)((MonsterSpawnManager.Stage * 1f) * (1 + MonsterSpawnManager.Stage * 0.02f));
        m_MonsterDamage = 1 + (int)((MonsterSpawnManager.Stage * 0.1f) * (1 + MonsterSpawnManager.Stage * 0.01f));
        m_MoveSpeed = 0.5f;
        m_AttackDelay00 = new WaitForSeconds(0.8f);
        m_AttackDelay01 = new WaitForSeconds(2.2f);
        m_MonsterGold = (1 + MonsterSpawnManager.Stage * 0.5f) * (1 + MonsterSpawnManager.Stage * 0.05f);
        m_MonsterKey = ObjectPoolingManager.m_Monster03Key;
        m_AttackRange = 1.5f;

        base.OnEnable();
    }
}
