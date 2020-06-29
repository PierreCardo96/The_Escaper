using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerHealth : Health
    {
        private Text healthText; 
        private void Start()
        {
            healthBar = PlayerUI.Instance.GetHealthBarSlider();
            healthText = PlayerUI.Instance.GetHealthText();
            string[] temp = healthText.text.Split(':');
            currentHealth = float.Parse(temp[1]);
        }

        public void IncreaseHealth(int healthAmount)
        {
            currentHealth += healthAmount;
            if(currentHealth > maxHealth)
            {
                maxHealth = currentHealth;
            }
            healthBar.value = currentHealth / maxHealth;
            healthText.text = $"Health: {currentHealth}";
        }

        protected override void ProcessDeath()
        {
            GetComponentInChildren<PlayerAnimator>().Die();
            GetComponent<DeathHandler>().HandleDeath();
            GetComponent<PlayerInputHandler>().enabled = false;
        }

        public override void TakeDamage(float damage)
        {
            currentHealth -= damage;
            healthText.text = $"Health: {currentHealth}";
            healthBar.value = currentHealth / maxHealth;
            if (healthBar.value <= 0)
            {
                healthText.text = "Health: 0";
                ProcessDeath();
            }
        }

    }
}
