using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] public int enemyHealth = 3;
        public GameObject enemy;

        private void Update()
        {
            Death();
            print(enemyHealth);
        }

        public void TakeDamage(int damage)
        {
            enemyHealth -= damage;
        }
    

        private void Death()
        {
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
                enemy.SetActive(false);
            }
        }
    }
}
