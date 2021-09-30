using System;
using System.Collections;
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
        private PlayerAnimator m_Animator;
        [SerializeField] private float attackRangeGround;
        [SerializeField] private float attackRangeAir;
        [SerializeField] private LayerMask enemies;
        public Transform attackLocationGround;
        public Transform attackLocationAir;
        [SerializeField]public List<Collider2D> enemiesNearby;

        private bool attacking;
        
     
        private void Awake()
        {
            m_Animator = GetComponent<PlayerAnimator>();
            m_Input = GetComponent<PlayerInput>();
            m_Coyote = GetComponent<CoyoteTime>();
        }

        private void Update()
        {
            if (!attacking) return;
            
            if (m_Coyote.canCoyote)
            {
                EnemiesInRange();
            }
            else
            {
                if (m_Coyote.isDashing) return;
                AirEnemiesInRange();
            }
            Attack();
            enemiesNearby.Clear();
        }


        private void EnemiesInRange()
        {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackLocationGround.position, attackRangeGround, enemies);
            foreach (var enemy in enemiesInRange)
            {
                if (!enemiesNearby.Contains(enemy))
                {
                    enemiesNearby.Add(enemy);
                }
            }
        }

        public void Attack()
        {
            print("Attack from animation" + transform.name);
            
            foreach (var enemy in enemiesNearby)
            {
                if (enemy.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    enemyHealth.TakeDamage(2);
                }
                if (enemy.TryGetComponent(out BossHealth bossHealth))
                {
                    bossHealth.TakeDamage(2);
                }
                print("I Attacked: " + enemy.transform.name);
                attacking = false;
            }
        }
        
        private void AirEnemiesInRange()
        {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackLocationAir.position, attackRangeAir, enemies);
            foreach (var enemy in enemiesInRange)
            {
                if (!enemiesNearby.Contains(enemy))
                {
                    enemiesNearby.Add(enemy);
                }
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

        public void Attacking()
        {
            attacking = true;
        }
    }
}
