using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    [SerializeField] GameObject m_PlayerAttackEffect00;

    [SerializeField] GameObject m_Monster00;


    public const int m_PlayerAttackEffect00Key = 100;

    public const int m_Monster00Key = 0;


    private Queue<GameObject> m_PlayerAttackEffect00Queue = new Queue<GameObject>();

    private Queue<GameObject> m_Monster00Queue = new Queue<GameObject>();


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
            // instance가 비어있을 경우 해당 객체를 넣어줌
            instance = this;
        }

        m_queueDic.Add(m_PlayerAttackEffect00Key, m_PlayerAttackEffect00Queue);

        m_queueDic.Add(m_Monster00Key, m_Monster00Queue);


        InitQueue(m_PlayerAttackEffect00, m_PlayerAttackEffect00Queue, 10);

        InitQueue(m_Monster00, m_Monster00Queue, 100);
    }

    // 오브젝트 풀 Queue에 오브젝트를 생성해서 채워주는 초기화 함수
    private void InitQueue(GameObject _obj, Queue<GameObject> _queue, int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            // 예상하지 않은 충돌을 방지하기 위해 멀리 떨어진 곳에서 생성
            GameObject obj = Instantiate(_obj, new Vector3(5000, 5000), Quaternion.identity);
            _queue.Enqueue(obj);

            obj.SetActive(false);
        }
    }

    // 사용한 오브젝트를 다시 큐에 넣기 위한 함수
    public void InsertQueue(GameObject _obj, int _queueKey)
    {
        // 오브젝트의 속성 초기화
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

    // 오브젝트 풀에서 사용할 오브젝트를 꺼내는 함수
    public GameObject GetQueue(int _queueKey)
    {
        GameObject obj = m_queueDic[_queueKey].Dequeue();
        obj.SetActive(true);
        // 큐에 오브젝트가 남아있지 않으면 추가 생성
        if (m_queueDic[_queueKey].Count < 1)
        {
            InitQueue(obj, m_queueDic[_queueKey], 10);
        }
        return obj;
    }
}

