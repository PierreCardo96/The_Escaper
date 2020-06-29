using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    public float damage = 30f;

    [SerializeField]
    protected string opponent;

    protected void DamageOpponent(Health opponentHealth)
    {
        opponentHealth?.TakeDamage(damage);
    }
}
