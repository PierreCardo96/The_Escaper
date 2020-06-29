using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    private PlayerAnimator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    public void RespondToAttackingInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAnimator?.UpdatePlayerState(PlayerState.FireBalling);
        }
    }

    public void ProcessEarthquake()
    {
        playerAnimator?.UpdatePlayerState(PlayerState.JumpAttacking);
    }
}
