using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAttacking playerAttacking;
    private MouseMovement mouseMovement;
    private PowersHotkey powersHotkey;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttacking = GetComponent<PlayerAttacking>();
        mouseMovement = GetComponentInChildren<MouseMovement>();
        powersHotkey = GetComponent<PowersHotkey>();
    }

    public void RespondToInput()
    {
        playerMovement.RespondToTranslationInput();
        playerAttacking.RespondToAttackingInput();
        mouseMovement.RespondToMouseMovement();
        powersHotkey.RespondToHotKey();
    }
}
