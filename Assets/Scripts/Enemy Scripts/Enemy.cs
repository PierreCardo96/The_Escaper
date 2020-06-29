using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health enemyHealth;
    private EnemyMovement enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<Health>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.GetHealth() > 0)
        {
            enemyMovement.ProcessEnemyMovement();
        }
    }
}
