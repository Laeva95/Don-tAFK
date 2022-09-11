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
    protected float m_AttackDelay;                // ���� ���� ����
    protected bool m_IsAttack;                    // ���� ���� �ߺ� ���� ����

    public Rigidbody2D Rigid => m_Rigid;

    private void Awake()
    {
        // ������Ʈ �ʱ�ȭ
        m_PlayerTransform = FindObjectOfType<Player>().transform;
        m_Rigid = GetComponent<Rigidbody2D>();
        m_Ani = GetComponent<Animator>();
        m_SpRen = GetComponent<SpriteRenderer>();
    }

    // ��� ���� Ŭ�������� ����ϴ� �����̹Ƿ� �θ� Ŭ�������� �ۼ�
    // �ʿ��� ������ ������ �ۼ� �� base.OnEnable()�� ���� ȣ��
    protected virtual void OnEnable()
    {
        m_MonsterHP = m_MonsterMaxHP;
        m_IsAttack = false;
        m_SpRen.color = Color.white;

        StartCoroutine(MonsterMove());
    }

    // ��� ���� Ŭ�������� ����ϴ� �����̹Ƿ� �θ� Ŭ�������� �ۼ�
    // �Ϻ� Ŭ���������� ���� �ۼ��� �ʿ䰡 �����Ƿ� ���� �Լ��� �ۼ�
    protected virtual IEnumerator MonsterMove()
    {
        while (gameObject.activeSelf)
        {
            Vector3 dir = (m_PlayerTransform.position - transform.position).normalized;

            transform.position += dir * m_MoveSpeed * 0.05f;

            yield return new WaitForSeconds(0.05f);
        }
    }
    protected virtual IEnumerator MonsterAttack(GameObject _obj)
    {
        m_IsAttack = true;

        yield return new WaitForSeconds(m_AttackDelay);

        m_IsAttack = false;
    }
    public virtual void MonsterOnDamage(int _damage)
    {
        m_MonsterHP -= _damage;

        StartCoroutine(MonsterOnDamageEffect());
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
        StopAllCoroutines();
    }
}
