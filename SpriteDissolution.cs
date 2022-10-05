using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDissolution : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] m_SpriteRenderers;    
    [SerializeField] private float m_DisssolutionSpeed;
        

    private void Update()
    {
        for(int i = 0; i < m_SpriteRenderers.Length; i++)
        {
            m_SpriteRenderers[i].color = new Color(m_SpriteRenderers[i].color.r, m_SpriteRenderers[i].color.g, m_SpriteRenderers[i].color.b, 
                                                                       m_SpriteRenderers[i].color.a - (m_DisssolutionSpeed * Time.deltaTime));

            if (m_SpriteRenderers[i].color.a <= 0) Destroy(gameObject);
        }       
    }
}
