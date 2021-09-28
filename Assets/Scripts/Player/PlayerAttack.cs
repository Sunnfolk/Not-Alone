using System.Collections;
using UnityEngine;

namespace Player
{
    
    public class PlayerAttack : MonoBehaviour
    {
        private PlayerInput m_Input;
        private CoyoteTime m_Coyote;
        [SerializeField] private float attackRange;
        [SerializeField] private LayerMask enemies;
        public Transform attackLocation;
        

        private void Awake()
        {
            m_Input = GetComponent<PlayerInput>();
            m_Coyote = GetComponent<CoyoteTime>();
        }
        /*
        private void Update()
        {
            if (!m_Input.attack) return;
            if (m_Coyote.canCoyote)
            {
                Attack();
            }
            else
            {
                if (m_Coyote.isDashing) return;
                AirAttack();
            }
        }

        private bool Attack()
        {
            Collider2D[] damage = Physics2D.OverlapCircleAll( attackLocation.position, attackRange, enemies);
        }

        private bool AirAttack()
        {
            Collider2D[] damage = Physics2D.OverlapCircleAll( attackLocation.position, attackRange, enemies);
        }

        private IEnumerator AttackCooldown()
        {
            
        } */
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackLocation.position, attackRange);
        }
    }
}
