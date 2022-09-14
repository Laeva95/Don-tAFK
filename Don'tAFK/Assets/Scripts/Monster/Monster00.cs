using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster00 : MeleeMonster
{
    protected override void OnEnable()
    {
        m_MonsterMaxHP = 5 + (int)((MonsterSpawnManager.Stage * 1f) * (1 + MonsterSpawnManager.Stage * 0.02f));
        m_MonsterDamage = 1 + (int)((MonsterSpawnManager.Stage * 0.2f) * (1 + MonsterSpawnManager.Stage * 0.02f));
        m_MoveSpeed = 0.5f;
        m_AttackDelay00 = new WaitForSeconds(0.8f);
        m_AttackDelay01 = new WaitForSeconds(0.2f);
        m_MonsterGold = (1 + MonsterSpawnManager.Stage * 0.3f) * (1 + MonsterSpawnManager.Stage * 0.05f);
        m_MonsterKey = ObjectPoolingManager.m_Monster00Key;

        base.OnEnable();
    }
}
