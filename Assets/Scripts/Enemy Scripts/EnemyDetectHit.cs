using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectHit : MonoBehaviour
{
    [SerializeField]
    string opponent;

    [SerializeField]
    float chasingForAttackingTime = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == opponent)
        {
            BroadcastMessageOnAttacked();
        }
    }

    public void BroadcastMessageOnAttacked()
    {
        //it calls all the methods SetIsAttacked in this gameobject and all of his childrens
        BroadcastMessage("SetIsAttacked", true);
        Invoke("SetIsAttackedToFalse", chasingForAttackingTime);
    }

    private void SetIsAttackedToFalse()
    {
        BroadcastMessage("SetIsAttacked", false);
    }
}
