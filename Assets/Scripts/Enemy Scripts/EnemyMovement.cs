using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    private Player player;

    [SerializeField]
    float speed = 1.5f;
    [SerializeField]
    float rotationSpeed = 1f;
    [SerializeField]
    float sprintingSpeed = 4f;
    [SerializeField]
    float rotationSprintingSpeed = 2.5f;

    [SerializeField]
    float viewAngle = 30f;
    [SerializeField]
    float attackingDistance = 1.5f;
    [SerializeField]
    float chaseDistance = 10f;

    private bool isAttacked = false;
    private EnemyPatroling enemyPatroling;



    private EnemyAnimator enemyAnimator;
    private EnemyState enemyState = EnemyState.Patroling;

    private void Awake()
    {
        enemyPatroling = GetComponent<EnemyPatroling>();
        enemyAnimator = GetComponent<EnemyAnimator>();
        player = FindObjectOfType<Player>();
    }
    // Start is called before the first frame update
    //void Start()
    //{
    //    player = FindObjectOfType<Player>();
    //    enemyPatroling = GetComponent<EnemyPatroling>();
    //    enemyAnimator = GetComponent<EnemyAnimator>();
    //}
    public void ProcessEnemyMovement()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        direction.y = 0f;//TODO: Check if it is neccessary
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);
        
        //player is alive, is in the radius and (is in the viewAngle or the enemy already attacking or chasing)
        if (player.GetHealth() > 0 && (playerDistance <= chaseDistance && 
            (angle<=viewAngle || enemyState != EnemyState.Patroling ) || isAttacked))
        {
            PlayerTracking(direction);
        }
        else
        {
            ProcessPatroling();
        }
    }
    private void ProcessChasing()
    {
        enemyState = EnemyState.Chasing;
        transform.Translate(0, 0, sprintingSpeed * Time.deltaTime);
        enemyAnimator.UpdateEnemyState(EnemyState.Chasing);
    }
    private void ProcessAttacking()
    {
        enemyState = EnemyState.Attacking;
        enemyAnimator.UpdateEnemyState(EnemyState.Attacking);
    }
    private void ProcessPatroling()
    {
        enemyState = EnemyState.Patroling;
        enemyAnimator.UpdateEnemyState(EnemyState.Patroling);
        enemyPatroling.Patrole(speed, rotationSpeed);
    }
    private void PlayerTracking(Vector3 direction)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                    Quaternion.LookRotation(direction), rotationSprintingSpeed * Time.deltaTime);
        if (direction.magnitude > attackingDistance)
        {
            ProcessChasing();
        }
        else
        {
            ProcessAttacking();
        }
    }

    public void SetIsAttacked(bool value)
    {
        isAttacked = value;
    }

    public void SlowDownMovement(float slowDownFactor)
    {
        if(slowDownFactor == 0)
        {
            return;
        }

        speed /= slowDownFactor;
        rotationSpeed /= slowDownFactor;

        sprintingSpeed /= slowDownFactor;
        rotationSprintingSpeed /= slowDownFactor;
    }
    public void CancelSlowDownMovement(float speedUpFactor)
    {
        SlowDownMovement(1 / speedUpFactor);
    }
}
