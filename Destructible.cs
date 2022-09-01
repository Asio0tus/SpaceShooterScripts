using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Destructible object on scene. That may have hitpoints.
/// </summary>
public class Destructible : Entity
{
    #region Properties
    /// <summary>
    /// Object ignores damage
    /// </summary>
    [SerializeField] private bool m_Indestructible;
    public bool IsIndestructible => m_Indestructible;

    /// <summary>
    /// Object`s hitpoints on starrt
    /// </summary>
    [SerializeField] private int m_HitPoints;

    /// <summary>
    /// Object`s current hitpoints
    /// </summary>
    private int m_CurrentHitPoints;
    public int HitPoints => m_CurrentHitPoints;
    #endregion

    #region Unity Events

    protected virtual void Start()
    {
        m_CurrentHitPoints = m_HitPoints;
    }

    #endregion

    #region Public API

    /// <summary>
    /// Object getting damage
    /// </summary>
    /// <param name="damage"> damage points </param>
    public void ApplyDamage(int damage)
    {
        if (m_Indestructible) return;

        m_CurrentHitPoints -= damage;

        if (m_CurrentHitPoints <= 0)
            OnDeath();
    }

    #endregion

    /// <summary>
    /// Override event. Base: Destroy object if HitPoits <= zero
    /// </summary>
    protected virtual void OnDeath()
    {
        m_EventOnDeath?.Invoke();
        Destroy(gameObject);        
    }

    [SerializeField] private UnityEvent m_EventOnDeath;
    public UnityEvent EventOnDeath => m_EventOnDeath;
}

