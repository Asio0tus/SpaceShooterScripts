using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupStats : Powerup
{
    public enum EffectType
    {
        AddAmmo,
        AddEnergy
    }

    [SerializeField] private EffectType m_EffectType;
    [SerializeField] private float m_Value;

    protected override void OnPickedUp(Spaceship ship)
    {
        if (m_EffectType == EffectType.AddEnergy)
            ship.AddEnergy((int) m_Value);

        if (m_EffectType == EffectType.AddAmmo)
            ship.AddAmmo((int) m_Value);
    }
}
