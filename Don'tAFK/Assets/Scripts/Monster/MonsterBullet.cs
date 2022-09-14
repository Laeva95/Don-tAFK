using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    private int m_Damage;

    private void OnEnable()
    {
        StartCoroutine(DespwanBullet());
    }
    IEnumerator DespwanBullet()
    {
        // 활성화 된 후 3초 동안 플레이어, 벽과 부딪히지 않았을 경우
        yield return new WaitForSeconds(3f);

        // 오브젝트가 아직 활성화 된 상태라면 비활성화 후 오브젝트 풀링 매니저 큐에 재삽입
        if (gameObject.activeSelf)
        {
            ObjectPoolingManager.Instance.InsertQueue(gameObject, ObjectPoolingManager.m_MonsterAttackEffect00Key);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && gameObject.activeSelf && collision.gameObject.activeSelf)
        {
            // 플레이어에 부딪힐 경우 데미지를 준 후 오브젝트 풀링 매니저 큐에 재삽입
            Player player = collision.gameObject.GetComponent<Player>();
            player.PlayerOnDamage(m_Damage);

            SoundManager.Instance.SoundPlay(SOUND_NAME.MONSTERATTACK);

            ObjectPoolingManager.Instance.InsertQueue(gameObject, ObjectPoolingManager.m_MonsterAttackEffect00Key);
        }
    }
    public void SetDamage(int _damage)
    {
        m_Damage = _damage;
    }
}
