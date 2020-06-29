using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class EnemyHealth : Health
    {
        [SerializeField]
        float destructionDelay = 1f;

        [SerializeField]
        Slider healthBarSlider;

        [SerializeField]
        float healthSpawnProbability = 0.2f;

        [SerializeField]
        HealthPickup potionBottle;

        private void Start()
        {
            healthBar = healthBarSlider;
        }
        protected override void ProcessDeath()
        {
            SpawnPotionWithProbability();
            DisableTheColliderOfDeadBody();
            GetComponent<EnemyAnimator>().Die();
            Destroy(gameObject, destructionDelay);
        }

        private void SpawnPotionWithProbability()
        {
            if(Random.value <= healthSpawnProbability)
            {
                Instantiate(potionBottle, transform.position, Quaternion.identity);
            }
        }

        private void DisableTheColliderOfDeadBody()
        {
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Rigidbody>().angularDrag = 0.05f;
            GetComponent<Rigidbody>().drag = 100;
        }
    }
}
