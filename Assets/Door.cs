using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Door : MonoBehaviour
{


    [SerializeField]
    private float doorOpenAngle = -90f;

    [SerializeField]
    private float smooth = 2f;

    [SerializeField]
    private List<Enemy> enemies = new List<Enemy>();

    private bool open = false;

    // Update is called once per frame
    void Update()
    {
        HandleOpeningDoor();
    }

    private void HandleOpeningDoor()
    {
        if(enemies.All(enemy => enemy == null))
        {
            if (!open)
            {
                FindObjectOfType<AudioManager>().Play("OpenJailDoor");
                open = true;
            }
            Open();
        }
    }

    private void Open()
    {
        Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
