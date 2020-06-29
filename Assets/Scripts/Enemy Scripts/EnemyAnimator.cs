using Assets.Scripts;
using Assets.Scripts.Enemy_Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateEnemyState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Patroling:
                animator.SetBool("isPatroling", true);
                animator.SetBool("isChasing", false);
                animator.SetBool("isAttacking", false);
                break;

            case EnemyState.Chasing:
                animator.SetBool("isChasing", true);
                animator.SetBool("isPatroling", false);
                animator.SetBool("isAttacking", false);
                break;
            case EnemyState.Attacking:
                animator.SetBool("isAttacking", true);
                animator.SetBool("isPatroling", false);
                animator.SetBool("isChasing", false);
                break;
            default:
                animator.SetBool("isAttacking", false);
                animator.SetBool("isPatroling", false);
                animator.SetBool("isChasing", false);
                break;
        }
    }

    public void Die()
    {
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        animator.SetBool("isDead", true);
    }

    public void DamagePlayer()
    {
        GetComponent<EnemyDamage>().Damage();
    }
}
