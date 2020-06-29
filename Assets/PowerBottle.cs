using Assets.Scripts.Player_Scripts.Powers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBottle : MonoBehaviour
{
    [SerializeField]
    PowerType powerType;

    private ActionBar actionBar;

    private void Start()
    {
        actionBar = PlayerUI.Instance.GetActionBar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("HealthPotion");
            actionBar.ActivatePower(powerType);
            Destroy(gameObject);
        }
    }
}
