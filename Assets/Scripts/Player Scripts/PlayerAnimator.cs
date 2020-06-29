using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimator : MonoBehaviour
{   
    [SerializeField]
    Vector3  offsetFromCollider =  new Vector3(0, -2.25f, 2.1f);
    [SerializeField]
    PlayerState playerState = PlayerState.Idle;

    [SerializeField]
    Animator animator;
    private Camera mainCamera;
    [SerializeField]
    BallShooter ballSpawner;

    [SerializeField]
    EarthquakeSpawner earthquakeSpawner;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        UpdateCharacterPosition();
    }

    private void UpdateCharacterPosition()
    {
        if (!animator.GetBool("isDead"))
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, mainCamera.transform.localEulerAngles.y, mainCamera.transform.localEulerAngles.z);
            transform.localPosition = mainCamera.transform.localPosition + offsetFromCollider;
        }
    }

    public void UpdatePlayerState(PlayerState state)
    {
        playerState = state;
        switch (playerState)
        {
            case PlayerState.Sprinting:
                animator.SetBool("isSprinting", true);
                animator.SetBool("isFireBalling", false);
                animator.SetBool("isJumpAttacking", false);
                break;
            case PlayerState.FireBalling:
                animator.SetBool("isFireBalling", true);
                break;
            case PlayerState.JumpAttacking:
                animator.SetBool("isJumpAttacking", true);
                break;
            default:
                animator.SetBool("isSprinting", false);
                animator.SetBool("isFireBalling", false);
                animator.SetBool("isJumpAttacking", false);
                break;
        }
    }

    public void ActivateWalkingAnimation(float verticalMoveInput, float horizontalMoveInput)
    {
        animator.SetFloat("MoveZ", verticalMoveInput);
        animator.SetFloat("MoveX", horizontalMoveInput);
        animator.SetBool("isSprinting", false);
        animator.SetBool("isFireBalling", false);
        animator.SetBool("isJumpAttacking", false);
    }

    public void SpawnFireBall()
    {
        ballSpawner.Shoot();
    }

    public void SpawnEarthquake()
    {
        earthquakeSpawner.Spawn();
    }
    public void Die()
    {
        animator.SetBool("isDead", true);
    }
}
