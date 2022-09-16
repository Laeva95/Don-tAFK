using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    [SerializeField] GameObject m_PlayerAttackEffect00;
    [SerializeField] GameObject m_MonsterAttackEffect00;

    [SerializeField] GameObject m_Monster00;
    [SerializeField] GameObject m_Monster01;
    [SerializeField] GameObject m_Monster02;
    [SerializeField] GameObject m_Monster03;


    public const int m_PlayerAttackEffect00Key = 100;
    public const int m_MonsterAttackEffect00Key = 101;

    public const int m_Monster00Key = 0;
    public const int m_Monster01Key = 1;
    public const int m_Monster02Key = 2;
    public const int m_Monster03Key = 3;


    private Queue<GameObject> m_PlayerAttackEffect00Queue = new Queue<GameObject>();
    private Queue<GameObject> m_MonsterAttackEffect00Queue = new Queue<GameObject>();

    private Queue<GameObject> m_Monster00Queue = new Queue<GameObject>();
    private Queue<GameObject> m_Monster01Queue = new Queue<GameObject>();
    private Queue<GameObject> m_Monster02Queue = new Queue<GameObject>();
    private Queue<GameObject> m_Monster03Queue = new Queue<GameObject>();


    public Dictionary<int, Queue<GameObject>> m_queueDic = new Dictionary<int, Queue<GameObject>>();

    private static ObjectPoolingManager instance;
    public static ObjectPoolingManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            // instance�� ������� ��� �ش� ��ü�� �־���
            instance = this;
        }

        m_queueDic.Add(m_PlayerAttackEffect00Key, m_PlayerAttackEffect00Queue);
        m_queueDic.Add(m_MonsterAttackEffect00Key, m_MonsterAttackEffect00Queue);

        m_queueDic.Add(m_Monster00Key, m_Monster00Queue);
        m_queueDic.Add(m_Monster01Key, m_Monster01Queue);
        m_queueDic.Add(m_Monster02Key, m_Monster02Queue);
        m_queueDic.Add(m_Monster03Key, m_Monster03Queue);


        InitQueue(m_PlayerAttackEffect00, m_PlayerAttackEffect00Queue, 10);
        InitQueue(m_MonsterAttackEffect00, m_MonsterAttackEffect00Queue, 10);

        InitQueue(m_Monster00, m_Monster00Queue, 20);
        InitQueue(m_Monster01, m_Monster01Queue, 20);
        InitQueue(m_Monster02, m_Monster02Queue, 20);
        InitQueue(m_Monster03, m_Monster03Queue, 20);
    }

    // ������Ʈ Ǯ Queue�� ������Ʈ�� �����ؼ� ä���ִ� �ʱ�ȭ �Լ�
    private void InitQueue(GameObject _obj, Queue<GameObject> _queue, int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            // �������� ���� �浹�� �����ϱ� ���� �ָ� ������ ������ ����
            GameObject obj = Instantiate(_obj, new Vector3(5000, 5000), Quaternion.identity);
            _queue.Enqueue(obj);

            obj.SetActive(false);
        }
    }

    // ����� ������Ʈ�� �ٽ� ť�� �ֱ� ���� �Լ�
    public void InsertQueue(GameObject _obj, int _queueKey)
    {
        // ������Ʈ�� �Ӽ� �ʱ�ȭ
        Rigidbody2D rigid = _obj.GetComponent<Rigidbody2D>();
        if (rigid != null)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = 0f;
        }
        _obj.transform.rotation = Quaternion.identity;

        m_queueDic[_queueKey].Enqueue(_obj);
        _obj.SetActive(false);
    }

    // ������Ʈ Ǯ���� ����� ������Ʈ�� ������ �Լ�
    public GameObject GetQueue(int _queueKey)
    {
        GameObject obj = m_queueDic[_queueKey].Dequeue();
        obj.SetActive(true);
        // ť�� ������Ʈ�� �������� ������ �߰� ����
        if (m_queueDic[_queueKey].Count < 1)
        {
            InitQueue(obj, m_queueDic[_queueKey], 10);
        }
        return obj;
    }
}

