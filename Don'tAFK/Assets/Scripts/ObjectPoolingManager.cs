using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{


    // Queue���� �����ϱ� ���� Dictionary
    public Dictionary<int, Queue<GameObject>> m_queueDic = new Dictionary<int, Queue<GameObject>>();

    // ������Ʈ Ǯ�� �Ŵ��� ����, ������Ƽ
    // ���� ��ü�� �����ϰ�, �ٸ� Ŭ�������� ���� ����� �� �ֵ��� �̱��� ������ ���
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

