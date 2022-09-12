using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerAttackPower { get; private set; }
    public float PlayerAttackSpeed { get; private set; }
    public float PlayerAttackArea { get; private set; }
    public int PlayerHP { get; private set; }
    public int PlayerHPRegen { get; private set; }
    public int PlayerArmor { get; private set; }

    private bool m_IsAttack;

    [SerializeField] LayerMask m_MonsterLayer;
    

    private void Awake()
    {
        PlayerInit();

        m_IsAttack = false;
    }
    public void PlayerInit()
    {
        PlayerAttackPower = PlayerStatus.Instance.PlayerAttackPower;
        PlayerAttackSpeed = PlayerStatus.Instance.PlayerAttackSpeed;
        PlayerAttackArea = PlayerStatus.Instance.PlayerAttackArea;
        PlayerHP = PlayerStatus.Instance.PlayerHP;
        PlayerHPRegen = PlayerStatus.Instance.PlayerHPRegen;
        PlayerArmor = PlayerStatus.Instance.PlayerArmor;
    }

    private void Update()
    {
        PlayerAttack();
    }
    void PlayerAttack()
    {
        if (!m_IsAttack && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(PlayerAttackCoroutine());
        }
    }
    IEnumerator PlayerAttackCoroutine()
    {
        m_IsAttack = true;

        GameObject obj = ObjectPoolingManager.Instance.GetQueue(ObjectPoolingManager.m_PlayerAttackEffect00Key);

        obj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));

        Collider2D[] cols = Physics2D.OverlapCircleAll(obj.transform.position, PlayerAttackArea, m_MonsterLayer);

        for (int i = 0; i < cols.Length; i++)
        {
            // ���Ϳ��� ������ �ο�
            Monster monster = cols[i].gameObject.GetComponent<Monster>();
            monster.MonsterOnDamage(PlayerAttackPower);

            // ���͸� �÷��̾��� �ݴ� �������� ���ĳ�
            Vector3 dir = (cols[i].gameObject.transform.position - transform.position).normalized;
            monster.Rigid.AddForce(dir * 1, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(PlayerAttackSpeed);

        m_IsAttack = false;
    }
}
