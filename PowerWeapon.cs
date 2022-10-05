using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWeapon : Powerup
{
    [SerializeField] private TurretProperties m_Properties;

    protected override void OnPickedUp(Spaceship ship)
    {
        ship.AssignWeapon(m_Properties);
    }
}
