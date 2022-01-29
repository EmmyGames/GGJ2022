using GGJ2022.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2022.Enemy
{
    public class EnemyStats : MonoBehaviour
    {
        public EnemyScript enemyScript;
        public float maxHealth;
        public float currentHealth;
        public Slider healthBar;
        public int buffInt;
        public Afflictions inventory;
        private void Start()
        {
            currentHealth = maxHealth;
        }
        
        public void TakeDamage(float damage)
        {
            // If the player has the correct buff.
            if (inventory.buffs[buffInt])
            {
                currentHealth -= damage;
                healthBar.value = (currentHealth / maxHealth);
                if (currentHealth <= 0)
                    Death();
            }
        }

        private void Death()
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
