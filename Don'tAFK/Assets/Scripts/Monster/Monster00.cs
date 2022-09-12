using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster00 : MeleeMonster
{
    protected override void OnEnable()
    {
        m_MonsterMaxHP = MonsterSpawnManager.Stage * 2;
        m_MonsterDamage = 1 + (int)(MonsterSpawnManager.Stage * 0.2f);
        m_MoveSpeed = 0.5f;
        m_AttackDelay = new WaitForSeconds(1f);
        m_MonsterGold = 1 + (int)(MonsterSpawnManager.Stage * 0.2f);
        m_MonsterKey = ObjectPoolingManager.m_Monster00Key;

        base.OnEnable();
    }
}
