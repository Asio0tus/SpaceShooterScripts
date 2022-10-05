using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawnerDebris : MonoBehaviour
{
    [SerializeField] private Destructible[] m_DebrisPrefab;
    [SerializeField] private CircleArea m_Area;
    [SerializeField] private int m_NumDebris;    
    [SerializeField] private float m_RandomSpeed;

    private void Start()
    {
        for(int i = 0; i < m_NumDebris; i++)
        {
            SpawnDebris();
        }
    }

    private void SpawnDebris()
    {
        int index = Random.Range(0, m_DebrisPrefab.Length);

        GameObject deb = Instantiate(m_DebrisPrefab[index].gameObject);

        deb.transform.position = m_Area.GetRandomInsideZone();
        deb.GetComponent<Destructible>().EventOnDeath.AddListener(OnDebrisDead);

        Rigidbody2D rb = deb.GetComponent<Rigidbody2D>();

        if(rb != null && m_RandomSpeed > 0)
        {
            rb.velocity = (Vector2) UnityEngine.Random.insideUnitSphere * m_RandomSpeed;
        }
    }

    private void OnDebrisDead()
    {
        SpawnDebris();
    }
}
