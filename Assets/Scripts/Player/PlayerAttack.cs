using System.Collections.Generic;
using Enemy;
using UnityEngine;
using Boss;

namespace Player
{
    
    public class PlayerAttack : MonoBehaviour
    {
        private PlayerInput m_Input;
        private CoyoteTime m_Coyote;
        [SerializeField] private float attackRangeGround;
        [SerializeField] private float attackRangeAir;
        [SerializeField] private LayerMask enemies;
        public Transform attackLocationGround;
        public Transform attackLocationAir;
        [SerializeField]public List<Collider2D> enemiesNearby;
     
        private void Awake()
        {
            m_Input = GetComponent<PlayerInput>();
            m_Coyote = GetComponent<CoyoteTime>();
        }
        
        private void Update()
        {
            if (!m_Input.attack) return;
            
            if (m_Coyote.canCoyote)
            {
                EnemiesInRange();
                Attack();
            }
            else
            {
                if (m_Coyote.isDashing) return;
                AirEnemiesInRange();
                Attack();
            }
            enemiesNearby.Clear();
        }

        private void EnemiesInRange()
        {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackLocationGround.position, attackRangeGround, enemies);
            foreach (var enemy in enemiesInRange)
            {
                enemiesNearby.Add(enemy);
            }
        }

        private void Attack()
        {
            foreach (var enemy in enemiesNearby)
            {
                if (enemy.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    enemyHealth.TakeDamage(5);
                }
                if (enemy.TryGetComponent(out BossHealth bossHealth))
                {
                    bossHealth.TakeDamage(5);
                }
                
                print("I Attacked: " + enemy.transform.name);
                
            }
            
        }
        
        private void AirEnemiesInRange()
        {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackLocationAir.position, attackRangeAir, enemies);
            foreach (var enemy in enemiesInRange)
            {
                enemiesNearby.Add(enemy);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            //ground
            Gizmos.DrawWireSphere(attackLocationGround.position, attackRangeGround);
            
            //Air
            Gizmos.DrawWireSphere(attackLocationAir.position, attackRangeAir);
        }
    }
}
