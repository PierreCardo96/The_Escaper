using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationContoller : MonoBehaviour
{
    [SerializeField]
    GameObject destination;
    // Start is called before the first frame update
    void Start()
    {
        destination.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectsOfType<Enemy>().Length == 0)
        {
            destination.SetActive(true);
        }
    }
}
