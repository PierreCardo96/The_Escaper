using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2;

    private PlayerAnimator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    public void RespondToTranslationInput()
    {
        float verticalMoveInput = Input.GetAxis("Vertical");
        float horizontalMoveInput = Input.GetAxis("Horizontal");
        float speed = moveSpeed;
        bool isSprinting = verticalMoveInput > 0 && Input.GetKey(KeyCode.LeftShift);
        if (isSprinting)
        {
            speed = moveSpeed;
        }
        float verticalTranslation = verticalMoveInput * speed * Time.deltaTime;
        float horizontalTranslation = horizontalMoveInput * speed * Time.deltaTime;

        transform.Translate(horizontalTranslation, 0, verticalTranslation);
        UpdateAnimation(verticalMoveInput, horizontalMoveInput, isSprinting);
        
    }

    private void UpdateAnimation(float verticalMoveInput, float horizontalMoveInput, bool isSprinting)
    {
        playerAnimator.ActivateWalkingAnimation(verticalMoveInput, horizontalMoveInput);
        if (isSprinting)
        {
            playerAnimator?.UpdatePlayerState(PlayerState.Sprinting);
        }
    }
}
