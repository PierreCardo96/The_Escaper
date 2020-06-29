using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : Damage
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        DamageOponent(other);
    }

    protected void DamageOponent(Collider other)
    {
        if (other.gameObject.tag == opponent)
        {
            DamageOpponent(other.gameObject.GetComponent<Health>());
        }
    }


}
