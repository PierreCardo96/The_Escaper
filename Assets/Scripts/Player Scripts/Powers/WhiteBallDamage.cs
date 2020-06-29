using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallDamage : BasicPlayerDamage
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != UnAffectedTag)
        {
            FindObjectOfType<AudioManager>().Play("WhiteExplosion");
            base.OnTriggerEnter(other);
        }
    }
}
