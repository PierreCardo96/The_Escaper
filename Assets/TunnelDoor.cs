using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TunnelDoor : MonoBehaviour
{
    [SerializeField]
    private float targetHeight = 0f;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private List<Enemy> enemies = new List<Enemy>();

    private Vector3 targetPosition;

    private bool open = false;

    private void Start()
    {
        targetPosition = new Vector3(transform.position.x, targetHeight, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        HandleOpeningDoor();
    }

    private void HandleOpeningDoor()
    {
        if (enemies.All(enemy => enemy == null))
        {
            if (!open)
            {
                FindObjectOfType<AudioManager>().Play("OpenGate");
                open = true;
            }
            Open();
        }
    }

    private void Open()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}