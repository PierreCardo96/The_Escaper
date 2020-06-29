using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallDamage : BasicPlayerDamage
{


    [SerializeField]
    GameObject coldPrefab;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != UnAffectedTag)
        {
            FindObjectOfType<AudioManager>().Play("IceExplosion");

            if (other.tag == opponent)
            {
                GameObject gameObject = Instantiate(coldPrefab, transform.position, Quaternion.identity);
                Cold cold = gameObject.GetComponent<Cold>();
                cold.SlowEnemy(other.gameObject.GetComponent<EnemyMovement>(), other.gameObject.GetComponentInChildren<Billboard>().transform);
            }
            base.OnTriggerEnter(other);
        }
    }

   
}
