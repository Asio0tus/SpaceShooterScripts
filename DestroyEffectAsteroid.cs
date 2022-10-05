using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectAsteroid : MonoBehaviour
{
    [SerializeField] Transform m_PositionDestroyObject;
    [SerializeField] Destructible m_Asteroid;
    [SerializeField] GameObject m_SpawnPrefab;
    [SerializeField] GameObject m_ExplosionPrefab;

    private void Start()
    {
        m_Asteroid.EventOnDeath.AddListener(OnDestroySpawn);
    }

    private void OnDestroySpawn()
    {
        var newExplosion = Instantiate(m_ExplosionPrefab);
        newExplosion.transform.position = m_PositionDestroyObject.position;
        Destroy(newExplosion, 1.0f);

        var newSpawn = Instantiate(m_SpawnPrefab);
        newSpawn.transform.position = m_PositionDestroyObject.position;
    }
}
