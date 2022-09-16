using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster01 : MeleeMonster
{
    protected override void OnEnable()
    {
        m_MonsterMaxHP = 10 + (int)((MonsterSpawnManager.Stage * 1.5f) * (1 + MonsterSpawnManager.Stage * 0.02f));
        m_MonsterDamage = 1 + (int)((MonsterSpawnManager.Stage * 0.2f) * (1 + MonsterSpawnManager.Stage * 0.02f));
        m_MoveSpeed = 0.3f;
        m_AttackDelay00 = new WaitForSeconds(0.8f);
        m_AttackDelay01 = new WaitForSeconds(0.2f);
        m_MonsterGold = (2 + MonsterSpawnManager.Stage * 0.6f);
        m_MonsterKey = ObjectPoolingManager.m_Monster01Key;

        base.OnEnable();
    }
}
