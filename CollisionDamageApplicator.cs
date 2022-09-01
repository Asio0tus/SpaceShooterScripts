using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageApplicator : MonoBehaviour
{
    [SerializeField] private float m_DamageConstant;
    [SerializeField] private float m_VelocityDamageModifier;

    public static string IgnoreTag = "WorldBoundary";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == IgnoreTag) return;

        var destructable = transform.root.GetComponent<Destructible>();

        if(destructable != null)
        {
            destructable.ApplyDamage((int)m_DamageConstant + (int)(m_VelocityDamageModifier * collision.relativeVelocity.magnitude));
        }
    }
}
