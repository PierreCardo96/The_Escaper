using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy_Scripts
{
    public class EnemyDamage : Damage
    {
        private Health playerHealth;

        private void Start()
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }

        public void Damage()
        {
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
            DamageOpponent(playerHealth);
        }
    }
}
