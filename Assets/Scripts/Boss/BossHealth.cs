using System;
using UnityEngine;
using UnityEngine.UI;

namespace Boss
{
    public class BossHealth : MonoBehaviour
    {
        [SerializeField] public int enemyHealth = 10;
        private Animator m_Animator;
        public bool dead = false;
        public Slider healthBar;

        private void Start()
        {
            dead = false;
            m_Animator = GetComponent<Animator>();
        }

        private void Update()
        {
            
            print("Boss Health = " + enemyHealth);
            healthBar.value = enemyHealth;
            
            
            if(enemyHealth > 0) return;
            Death();
            
        }

        public void PhaseTwo()
        {
            if (enemyHealth >= enemyHealth/2)
            {
                
            }
        }
        public void TakeDamage(int damage)
        {
            enemyHealth -= damage;
        }
    

        private void Death()
        {
            if (enemyHealth <= 0);
            {
                dead = true;
                m_Animator.SetFloat("Death", 2);
            }
        }
        
    }
}
