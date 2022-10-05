using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBoostSpeed : Powerup
{
    [SerializeField] private int m_BoostValue;
    [SerializeField] private float m_MaxTime;    

    protected override void OnPickedUp(Spaceship ship)
    {
        ship.OnSpeedBoost(m_BoostValue, m_MaxTime);
    }
}
