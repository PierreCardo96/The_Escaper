using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBallDamage : BasicPlayerDamage
{
    [SerializeField]
    float radius = 3;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != UnAffectedTag)
        {
            FindObjectOfType<AudioManager>().Play("LightningExplosion");
            DamageEnemeisInRadius(other);
            base.OnTriggerEnter(other);
        }
    }

    private void DamageEnemeisInRadius(Collider other)
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies)
        {
            if(enemy.gameObject != other.gameObject && Distance(other.transform.position, enemy.transform.position) <= radius)
            {
                Instantiate(hitEffect, enemy.transform.position, Quaternion.identity);
                DamageOpponent(enemy.GetComponent<Health>());
                enemy.GetComponent<EnemyDetectHit>().BroadcastMessageOnAttacked();
            }
        }
    }

    private float Distance(Vector3 vector1, Vector3 vector2)
    {
        return Vector3.Distance(vector1, vector2);
    }
}
