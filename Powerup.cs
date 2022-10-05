using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class Powerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Spaceship ship = collision.transform.root.GetComponent<Spaceship>();

        if(ship != null && Player.Instance.ActiveShip)
        {
            OnPickedUp(ship);
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickedUp(Spaceship ship);
}
