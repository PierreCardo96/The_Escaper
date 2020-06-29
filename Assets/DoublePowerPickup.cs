using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePowerPickup : MonoBehaviour
{
    [SerializeField]
    int factor = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("HealthPotion");
            FindObjectOfType<Player>().IncreasePowers(factor);
            Destroy(gameObject);
        }
    }
}
