using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMonster : Monster
{
    protected float m_AttackRange;


    protected override IEnumerator MonsterMove()
    {
        yield return new WaitForSeconds(1.5f);
        while (gameObject.activeSelf)
        {
            Vector3 dir = (m_PlayerTransform.position - transform.position).normalized;

            if(Vector3.Distance(m_PlayerTransform.position, transform.position) < m_AttackRange)
            {
                yield return StartCoroutine(MonsterRangeAttack());
            }
            else
            {
                transform.position += dir * m_MoveSpeed * 0.05f;
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    protected IEnumerator MonsterRangeAttack()
    {
        m_IsAttack = true;

        m_Ani.SetTrigger("Attack");

        yield return m_AttackDelay00;

        if (m_MonsterHP > 0)
        {
            SoundManager.Instance.SoundPlay(SOUND_NAME.MONSTERATTACK2);

            GameObject bullet = ObjectPoolingManager.Instance.GetQueue(ObjectPoolingManager.m_MonsterAttackEffect00Key);

            // 몬스터 불렛에 데미지 부여
            MonsterBullet pBullet = bullet.GetComponent<MonsterBullet>();
            pBullet.SetDamage(m_MonsterDamage);

            bullet.transform.position = gameObject.transform.position;

            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();

            Vector3 _dir = (m_PlayerTransform.position - transform.position).normalized;

            rigid.velocity = _dir * 2f;
        }

        yield return m_AttackDelay01;

        m_IsAttack = false;
    }
}
