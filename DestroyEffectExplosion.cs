using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyEffectExplosion : MonoBehaviour
{
    [SerializeField] Transform m_PositionDestroyObject;
    [SerializeField] Spaceship m_Ship;
    [SerializeField] GameObject m_ExplosionPrefab;

    private void Start()
    {
        m_Ship.EventOnDeath.AddListener(OnDestroyExplosion);
    }

    private void OnDestroyExplosion()
    {
        var newExplosion = Instantiate(m_ExplosionPrefab);
        newExplosion.transform.position = m_PositionDestroyObject.position;

        Destroy(newExplosion, 1.0f);
    }

    
}
