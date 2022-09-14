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
    public float PlayerGoldLevel { get; private set; }
    public float PlayerRebirthLevel { get; private set; }
    public float PlayerAutoAttackLevel { get; private set; }
    public int PlayerAllAttackLevel { get; private set; }
    public int PlayerStageCountLevel { get; private set; }

    private bool m_IsAttack;
    SpriteRenderer m_SpRen;

    WaitForSeconds m_OneSec = new WaitForSeconds(1f);
    WaitForSeconds m_miniSec = new WaitForSeconds(0.05f);

    [SerializeField] Animator m_CameraAni;
    [SerializeField] LayerMask m_MonsterLayer;
    [SerializeField] Text m_PlayerHPText;
    [SerializeField] Text m_FullscreenAttackText;
    [SerializeField] Text m_AutoTouchText;



    private void Awake()
    {
        PlayerInit();

        m_IsAttack = false;
        m_SpRen = GetComponent<SpriteRenderer>();

        StartCoroutine(PlayerAutoAttack());
        StartCoroutine(PlayerAllAttack());
        StartCoroutine(PlayerHPRegenCoroutine());
    }
    public void PlayerInit()
    {
        PlayerAttackPower = PlayerStatus.Instance.PlayerAttackPower;
        PlayerAttackSpeed = PlayerStatus.Instance.PlayerAttackSpeed;
        PlayerAttackArea = PlayerStatus.Instance.PlayerAttackArea;
        PlayerMaxHP = PlayerStatus.Instance.PlayerMaxHP;
        PlayerHPRegen = PlayerStatus.Instance.PlayerHPRegen;
        PlayerArmor = PlayerStatus.Instance.PlayerArmor;
        PlayerGoldLevel = PlayerStatus.Instance.PlayerGoldLevel;
        PlayerRebirthLevel = PlayerStatus.Instance.PlayerRebirthLevel;
        PlayerAutoAttackLevel = PlayerStatus.Instance.PlayerAutoAttackLevel;
        PlayerAllAttackLevel = PlayerStatus.Instance.PlayerAllAttackLevel;
        PlayerStageCountLevel = PlayerStatus.Instance.PlayerStageCountLevel;

        Debug.Log(PlayerAttackPower);
        Debug.Log(PlayerAttackSpeed);
        Debug.Log(PlayerAttackArea);
        Debug.Log(PlayerMaxHP);
        Debug.Log(PlayerHPRegen);
        Debug.Log(PlayerArmor);
        Debug.Log(PlayerGoldLevel);
        Debug.Log(PlayerRebirthLevel);
        Debug.Log(PlayerAutoAttackLevel);
        Debug.Log(PlayerAllAttackLevel);
        Debug.Log(PlayerStageCountLevel);


        PlayerHP = PlayerMaxHP;
        m_PlayerHPText.text = PlayerHP.ToString();
    }

    private void Update()
    {
        PlayerAttackCheck();
    }
    void PlayerAttackCheck()
    {
        if (!m_IsAttack && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(PlayerAttackCoroutine());
        }
    }
    IEnumerator PlayerAttackCoroutine()
    {
        m_IsAttack = true;

        PlayerAttack();

        yield return new WaitForSeconds(PlayerAttackSpeed);

        m_IsAttack = false;
    }
    void PlayerAttack()
    {
        GameObject obj = ObjectPoolingManager.Instance.GetQueue(ObjectPoolingManager.m_PlayerAttackEffect00Key);

        obj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));

        Collider2D[] cols = Physics2D.OverlapCircleAll(obj.transform.position, PlayerAttackArea, m_MonsterLayer);

        for (int i = 0; i < cols.Length; i++)
        {
            if (!cols[i].gameObject.activeSelf)
            {
                continue;
            }
            // ���Ϳ��� ������ �ο�
            Monster monster = cols[i].gameObject.GetComponent<Monster>();
            monster.MonsterOnDamage(PlayerAttackPower);

            // ���͸� �÷��̾��� �ݴ� �������� ���ĳ�
            Vector3 dir = (cols[i].gameObject.transform.position - transform.position).normalized;
            monster.Rigid.AddForce(dir * 0.3f, ForceMode2D.Impulse);
        }

        SoundManager.Instance.SoundPlay(SOUND_NAME.PLAYERATTACK);
    }

    public void PlayerOnDamage(int _damage)
    {
        int damage = _damage - PlayerArmor;

        if (damage <= 1)
        {
            damage = 1;
        }

        PlayerHP -= damage;

        if (PlayerHP <= 0)
        {
            GameManager.Instance.GameOver();
        }

        m_PlayerHPText.text = PlayerHP.ToString();

        StartCoroutine(PlayerOnDamageEffect());
    }
    IEnumerator PlayerOnDamageEffect()
    {
        m_SpRen.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        m_SpRen.color = Color.white;
    }

    IEnumerator PlayerAutoAttack()
    {
        yield return new WaitForSeconds(1f);
        while (gameObject.activeSelf)
        {
            for (int i = 1; i <= PlayerAutoAttackLevel * 20; i++)
            {
                yield return m_miniSec;
                m_AutoTouchText.text = $"{PlayerAutoAttackLevel - (i * 0.05f):0.00}\nsec";
            }

            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 2.5f, m_MonsterLayer);
            // ���� ����� Ÿ��
            Transform target = null;

            // ���Ͱ� �ϳ��� �����ϴ� ��� ����
            if (cols.Length > 0)
            {
                // ���� ����� Ÿ�ٰ��� �Ÿ� ����
                float targetDistance = Mathf.Infinity;

                // ��� ���Ϳ��� �Ÿ� ��
                for (int i = 0; i < cols.Length; i++)
                {
                    float distance = Vector3.SqrMagnitude(transform.position - cols[i].transform.position);

                    // ���� �Ÿ����� �� ����� ���Ͱ� ������ ��� �ش� ���Ϳ��� �Ÿ�, Ʈ������ ����
                    if (targetDistance > distance)
                    {
                        targetDistance = distance;
                        target = cols[i].transform;
                    }
                }
            }

            if (target != null)
            {
                GameObject obj = ObjectPoolingManager.Instance.GetQueue(ObjectPoolingManager.m_PlayerAttackEffect00Key);

                obj.transform.position = target.position;

                Collider2D[] cols2 = Physics2D.OverlapCircleAll(obj.transform.position, PlayerAttackArea, m_MonsterLayer);

                for (int i = 0; i < cols2.Length; i++)
                {
                    if (!cols2[i].gameObject.activeSelf)
                    {
                        continue;
                    }
                    // ���Ϳ��� ������ �ο�
                    Monster monster = cols2[i].gameObject.GetComponent<Monster>();
                    monster.MonsterOnDamage(PlayerAttackPower);

                    // ���͸� �÷��̾��� �ݴ� �������� ���ĳ�
                    Vector3 dir = (cols2[i].gameObject.transform.position - transform.position).normalized;
                    monster.Rigid.AddForce(dir * 0.3f, ForceMode2D.Impulse);
                }
                SoundManager.Instance.SoundPlay(SOUND_NAME.PLAYERATTACK);
            }
        }
    }
    IEnumerator PlayerAllAttack()
    {
        yield return new WaitForSeconds(1f);
        while (gameObject.activeSelf)
        {
            for (int i = 1; i <= PlayerAllAttackLevel; i++)
            {
                yield return m_OneSec;
                m_FullscreenAttackText.text = $"{PlayerAllAttackLevel - i}\nsec";
            }

            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 3f, m_MonsterLayer);

            for (int i = 0; i < cols.Length; i++)
            {
                if (!cols[i].gameObject.activeSelf)
                {
                    continue;
                }
                // ���Ϳ��� ������ �ο�
                Monster monster = cols[i].gameObject.GetComponent<Monster>();
                monster.MonsterOnDamage(PlayerAttackPower);

                // ���͸� �÷��̾��� �ݴ� �������� ���ĳ�
                Vector3 dir = (cols[i].gameObject.transform.position - transform.position).normalized;
                monster.Rigid.AddForce(dir * 0.3f, ForceMode2D.Impulse);
            }
            SoundManager.Instance.SoundPlay(SOUND_NAME.PLAYERALLATTACK);
            m_CameraAni.SetTrigger("AllAttack");
        }
    }

    IEnumerator PlayerHPRegenCoroutine()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(1f);

            PlayerHP += PlayerHPRegen;

            if (PlayerHP >= PlayerMaxHP)
            {
                PlayerHP = PlayerMaxHP;
            }

            m_PlayerHPText.text = PlayerHP.ToString();
        }
    }
}
