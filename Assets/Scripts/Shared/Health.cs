using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    [SerializeField]
    protected float maxHealth = 100f;
    protected Slider healthBar;

    protected float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public float GetHealth()
    {
        return healthBar.value;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth / maxHealth;
        if(healthBar.value <= 0)
        {
            ProcessDeath();
        }
    }

    protected abstract void ProcessDeath();
}
