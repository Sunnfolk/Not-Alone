using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] public int enemyHealth = 3;

        private void Update()
        {
            Death();
        }

        public void TakeDamage()
        {
            enemyHealth -= 1;
        }
    

        private void Death()
        {
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
