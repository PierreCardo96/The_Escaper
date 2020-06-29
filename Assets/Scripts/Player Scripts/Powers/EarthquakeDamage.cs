using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeDamage : BasicPlayerDamage
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != UnAffectedTag && other.gameObject.tag != "Player")
        {
            FindObjectOfType<AudioManager>().Play("FireExplosion");
            base.OnTriggerEnter(other);
        }
    }

    public float GetProcessTime()
    {
        return destroyDelay;
    }
}
