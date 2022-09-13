using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    protected Transform m_PlayerTransform;        // �÷��̾� ��ġ
    protected Rigidbody2D m_Rigid;                // ���� ������ٵ�
    protected Animator m_Ani;                     // ���� �ִϸ�����
    protected SpriteRenderer m_SpRen;             // ���� ��������Ʈ ������
    protected int m_MonsterMaxHP;                 // ���� �ִ� ü��
    protected int m_MonsterHP;                    // ���� ü��
    protected int m_MonsterDamage;                // ���� ���ݷ�
    protected float m_MoveSpeed;                  // ���� �̵� �ӵ�
    protected WaitForSeconds m_AttackDelay00;                // ���� ���� �� ����
    protected WaitForSeconds m_AttackDelay01;                // ���� ���� �� ����
    protected bool m_IsAttack;                    // ���� ���� �ߺ� ���� ����
    protected float m_MonsterGold;
    protected int m_MonsterKey;

    protected WaitForSeconds m_MoveDelay;                // ���� �̵� ����
    public Rigidbody2D Rigid => m_Rigid;

    private void Awake()
    {
        // ������Ʈ �ʱ�ȭ
        m_PlayerTransform = FindObjectOfType<Player>().transform;
        m_Rigid = GetComponent<Rigidbody2D>();
        m_Ani = GetComponent<Animator>();
        m_SpRen = GetComponent<SpriteRenderer>();
        m_MoveDelay = new WaitForSeconds(0.025f);
    }

    // ��� ���� Ŭ�������� ����ϴ� �����̹Ƿ� �θ� Ŭ�������� �ۼ�
    // �ʿ��� ������ ������ �ۼ� �� base.OnEnable()�� ���� ȣ��
    protected virtual void OnEnable()
    {
        m_MonsterHP = m_MonsterMaxHP;
        m_IsAttack = false;
        m_SpRen.color = Color.white;
        MonsterSpawnManager.m_MonsterCount++;

        StartCoroutine(MonsterMove());
    }

    // ��� ���� Ŭ�������� ����ϴ� �����̹Ƿ� �θ� Ŭ�������� �ۼ�
    // �Ϻ� Ŭ���������� ���� �ۼ��� �ʿ䰡 �����Ƿ� ���� �Լ��� �ۼ�
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

    // ���� �ǰ� ����Ʈ �ڷ�ƾ
    protected IEnumerator MonsterOnDamageEffect()
    {
        m_SpRen.color = Color.red;
        yield return new WaitForSeconds(0.2f);

        m_SpRen.color = Color.white;
    }



    // �÷��̾�� �ε����� �� ȣ��Ǵ� �Լ�
    // ��� ���ʹ� �÷��̾�� �浹�� Attack�� �����ϹǷ� �θ� Ŭ�������� �ۼ�
    private void OnCollisionStay2D(Collision2D collision)
    {
        // �÷��̾�� �浹���� ���, ���� ���� ��� ���� �ƴ϶�� ����
        if (collision.transform.tag == "Player" && !m_IsAttack && gameObject.activeSelf)
        {
            StartCoroutine(MonsterAttack(collision.gameObject));
        }
    }

    // ��Ȱ��ȭ�� ��� �ڷ�ƾ ����
    private void OnDisable()
    {
        MonsterSpawnManager.m_MonsterCount--;
        StopAllCoroutines();
    }
}
