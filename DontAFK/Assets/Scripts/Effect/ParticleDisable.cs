using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDisable : MonoBehaviour
{
    void OnEnable()
    {
        ParticleSystem particle = gameObject.GetComponent<ParticleSystem>();
        particle.Play();
        StartCoroutine(ParticleDestroy());
    }
    IEnumerator ParticleDestroy()
    {
        yield return new WaitForSeconds(0.5f);

        ObjectPoolingManager.Instance.InsertQueue(gameObject, ObjectPoolingManager.m_PlayerAttackEffect00Key);
    }
}
