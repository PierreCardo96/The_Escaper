using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDamage : BasicPlayerDamage
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != UnAffectedTag)
        {
            FindObjectOfType<AudioManager>().Play("FireExplosion");
            base.OnTriggerEnter(other);
        }
    }
}
