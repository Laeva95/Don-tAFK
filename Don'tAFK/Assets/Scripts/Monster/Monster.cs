using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected Transform m_PlayerTransform;        // 플레이어 위치
    protected Rigidbody2D m_Rigid;                // 몬스터 리지드바디
    protected Animator m_Ani;                     // 몬스터 애니메이터
    protected SpriteRenderer m_SpRen;             // 몬스터 스프라이트 렌더터
    protected int m_MonsterMaxHP;                 // 몬스터 최대 체력
    protected int m_MonsterHP;                    // 몬스터 체력
    protected int m_MonsterDamage;                // 몬스터 공격력
    protected float m_MoveSpeed;                  // 몬스터 이동 속도
    protected WaitForSeconds m_AttackDelay00;                // 몬스터 공격 전 간격
    protected WaitForSeconds m_AttackDelay01;                // 몬스터 공격 후 간격
    protected bool m_IsAttack;                    // 몬스터 공격 중복 방지 변수
    protected float m_MonsterGold;
    protected int m_MonsterKey;

    protected WaitForSeconds m_MoveDelay;                // 몬스터 이동 간격
    public Rigidbody2D Rigid => m_Rigid;

    private void Awake()
    {
        // 컴포넌트 초기화
        m_PlayerTransform = FindObjectOfType<Player>().transform;
        m_Rigid = GetComponent<Rigidbody2D>();
        m_Ani = GetComponent<Animator>();
        m_SpRen = GetComponent<SpriteRenderer>();
        m_MoveDelay = new WaitForSeconds(0.025f);
    }

    // 모든 몬스터 클래스에서 사용하는 내용이므로 부모 클래스에서 작성
    // 필요한 내용은 개별로 작성 후 base.OnEnable()을 통해 호출
    protected virtual void OnEnable()
    {
        m_MonsterHP = m_MonsterMaxHP;
        m_IsAttack = false;
        m_SpRen.color = Color.white;
        MonsterSpawnManager.m_MonsterCount++;

        StartCoroutine(MonsterMove());
    }

    // 모든 몬스터 클래스에서 사용하는 내용이므로 부모 클래스에서 작성
    // 일부 클래스에서는 따로 작성할 필요가 있으므로 가상 함수로 작성
    protected virtual IEnumerator MonsterMove()
    {
        yield return new WaitForSeconds(1f);

        while (gameObject.activeSelf)
        {
            if(!m_IsAttack)
            { 
                Vector3 dir = (m_PlayerTransform.position - transform.position).normalized;

                transform.position += dir * m_MoveSpeed * 0.025f;

                m_Ani.SetBool("IsMove", true);
            }
            else
            {
                m_Ani.SetBool("IsMove", false);
            }

            yield return m_MoveDelay;
        }
    }
    protected virtual IEnumerator MonsterAttack(GameObject _obj)
    {
        m_IsAttack = true;

        m_Ani.SetTrigger("Attack");

        yield return m_AttackDelay00;

        Player player = _obj.GetComponent<Player>();

        if (m_MonsterHP > 0)
        {
            player.PlayerOnDamage(m_MonsterDamage);
        }

        yield return m_AttackDelay01;

        m_IsAttack = false;
    }
    public virtual void MonsterOnDamage(int _damage)
    {
        m_MonsterHP -= _damage;

        StartCoroutine(MonsterOnDamageEffect());

        if (m_MonsterHP <= 0)
        {
            StartCoroutine(MonsterDead());
        }
    }
    protected IEnumerator MonsterDead()
    {
        m_Ani.SetTrigger("Dead");

        yield return new WaitForSeconds(0.5f);

        ObjectPoolingManager.Instance.InsertQueue(gameObject, m_MonsterKey);
        PlayerResource.Instance.PlayerGold += (int)(m_MonsterGold * PlayerStatus.Instance.PlayerGoldLevel);
    }

    // 몬스터 피격 이펙트 코루틴
    protected IEnumerator MonsterOnDamageEffect()
    {
        m_SpRen.color = Color.red;
        yield return new WaitForSeconds(0.2f);

        m_SpRen.color = Color.white;
    }



    // 플레이어와 부딪혔을 때 호출되는 함수
    // 모든 몬스터는 플레이어와 충돌시 Attack을 실행하므로 부모 클래스에서 작성
    private void OnCollisionStay2D(Collision2D collision)
    {
        // 플레이어와 충돌했을 경우, 현재 공격 대기 중이 아니라면 실행
        if (collision.transform.tag == "Player" && !m_IsAttack && gameObject.activeSelf)
        {
            StartCoroutine(MonsterAttack(collision.gameObject));
        }
    }

    // 비활성화시 모든 코루틴 종료
    private void OnDisable()
    {
        MonsterSpawnManager.m_MonsterCount--;
        StopAllCoroutines();
    }
}
