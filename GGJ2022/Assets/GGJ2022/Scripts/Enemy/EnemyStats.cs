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
        private void Start()
        {
            currentHealth = maxHealth;
        }
        
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            healthBar.value = (currentHealth / maxHealth);
            if (currentHealth <= 0)
                Death();
        }

        private void Death()
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
