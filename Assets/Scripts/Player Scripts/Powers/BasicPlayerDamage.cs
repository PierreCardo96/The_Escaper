using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicPlayerDamage : DamageOnCollision
{
    [SerializeField]
    protected GameObject hitEffect;

    [SerializeField]
    protected string UnAffectedTag;

    [SerializeField]
    protected float destroyDelay = 0f;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, destroyDelay);
    }
}
