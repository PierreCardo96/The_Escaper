using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MassGravity : MonoBehaviour
{
    [SerializeField]
    float smooth = 1f;

    private void Awake()
    {
        FreezeRotation();
    }

    private void FreezeRotation()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; //we rotate the rotations of the mass manually by the planet
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        float smooth = 1f;
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out hitInfo))
        {
            transform.position = hitInfo.point;
            Quaternion target = Quaternion.FromToRotation(transform.up, hitInfo.normal) * transform.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smooth);
        }
    }
}
