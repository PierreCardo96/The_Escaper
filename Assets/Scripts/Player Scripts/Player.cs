using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Health playerHealth;
    private PlayerInputHandler playerInputHandler;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<Health>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerHealth.GetHealth() > 0)
        {
            playerInputHandler.RespondToInput();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

   public float GetHealth()
    {
        return playerHealth.GetHealth();
    }

    public void IncreasePowers(int factor)
    {
        FindObjectOfType<BallShooter>().IncreaseDamageOfPowers(factor);    
        FindObjectOfType<EarthquakeSpawner>().IncreaseDamageOfPower(factor);    
    }
}
