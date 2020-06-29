using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField]
    int healthAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("HealthPotion");
            FindObjectOfType<PlayerHealth>().IncreaseHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
