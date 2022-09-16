using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster02 : MeleeMonster
{
    protected override void OnEnable()
    {
        m_MonsterMaxHP = 5 + (int)((MonsterSpawnManager.Stage * 0.4f) * (1 + MonsterSpawnManager.Stage * 0.01f));
        m_MonsterDamage = 1 + (int)((MonsterSpawnManager.Stage * 0.08f) * (1 + MonsterSpawnManager.Stage * 0.01f));
        m_MoveSpeed = 0.75f;
        m_AttackDelay00 = new WaitForSeconds(0.8f);
        m_AttackDelay01 = new WaitForSeconds(0.2f);
        m_MonsterGold = (1 + MonsterSpawnManager.Stage * 0.3f);
        m_MonsterKey = ObjectPoolingManager.m_Monster02Key;

        base.OnEnable();
    }
}
