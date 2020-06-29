using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePowerSpawner : MonoBehaviour
{
    [SerializeField]
    DoublePowerPickup doublePowerBottle;

    private Health health;
    private bool droped = false;

    private void Start()
    {
        health = GetComponent<Health>();    
    }

    private void Update()
    {
        if(health.GetHealth() <= 0 && !droped)
        {
            droped = true;
            Instantiate(doublePowerBottle, transform.position, Quaternion.identity);
        }
    }
}
