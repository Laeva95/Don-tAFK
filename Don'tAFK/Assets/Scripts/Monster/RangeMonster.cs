using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMonster : Monster
{
    private float m_AttackRange;


    protected override IEnumerator MonsterMove()
    {
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

        yield return m_AttackDelay00;

        m_IsAttack = false;
    }
}
