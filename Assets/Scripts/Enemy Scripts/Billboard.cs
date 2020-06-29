using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//It's responsible for making the health bar of the enemy facing the camera always
public class Billboard : MonoBehaviour
{
    private Camera playerCamera;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void LateUpdate()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        //Look in the same direction of the camera
        transform.LookAt(transform.position + playerCamera.transform.forward);
    }
}
