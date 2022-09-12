using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int PlayerAttackPower { get; private set; }
    public float PlayerAttackSpeed { get; private set; }
    public float PlayerAttackArea { get; private set; }
    public int PlayerHP { get; private set; }
    public int PlayerMaxHP { get; private set; }
    public int PlayerHPRegen { get; private set; }
    public int PlayerArmor { get; private set; }

    private bool m_IsAttack;
    SpriteRenderer m_SpRen;

    [SerializeField] LayerMask m_MonsterLayer;
    [SerializeField] Text m_PlayerHPText;
    

    private void Awake()
    {
        PlayerInit();

        m_IsAttack = false;
        m_SpRen = GetComponent<SpriteRenderer>();
    }
    public void PlayerInit()
    {
        PlayerAttackPower = PlayerStatus.Instance.PlayerAttackPower;
        PlayerAttackSpeed = PlayerStatus.Instance.PlayerAttackSpeed;
        PlayerAttackArea = PlayerStatus.Instance.PlayerAttackArea;
        PlayerMaxHP = PlayerStatus.Instance.PlayerMaxHP;
        PlayerHPRegen = PlayerStatus.Instance.PlayerHPRegen;
        PlayerArmor = PlayerStatus.Instance.PlayerArmor;

        PlayerHP = PlayerMaxHP;
        m_PlayerHPText.text = PlayerHP.ToString();
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
            // 몬스터에게 데미지 부여
            Monster monster = cols[i].gameObject.GetComponent<Monster>();
            monster.MonsterOnDamage(PlayerAttackPower);

            // 몬스터를 플레이어의 반대 방향으로 밀쳐냄
            Vector3 dir = (cols[i].gameObject.transform.position - transform.position).normalized;
            monster.Rigid.AddForce(dir * 0.5f, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(PlayerAttackSpeed);

        m_IsAttack = false;
    }

    public void PlayerOnDamage(int _damage)
    {
        PlayerHP -= _damage;
        m_PlayerHPText.text = PlayerHP.ToString();

        StartCoroutine(PlayerOnDamageEffect());
    }
    IEnumerator PlayerOnDamageEffect()
    {
        m_SpRen.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        m_SpRen.color = Color.white;
    }
}
