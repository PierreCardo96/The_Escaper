using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    private string playerTag;

    private void Start()
    {
        playerTag = FindObjectOfType<Player>().tag;    
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == playerTag)
        {
            FindObjectOfType<SceneLoader>().LoadNextLevel();
        }
    }
}
