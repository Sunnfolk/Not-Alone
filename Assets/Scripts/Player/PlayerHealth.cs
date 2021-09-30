using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] public int health = 10;
        public int numberOfHearts;

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite halfHeart;
        public Sprite emptyHeart;   

        private CoyoteTime m_Dash;
        private bool m_Invulnerable;
        [SerializeField] private float invulnerabilityTimer = 0.5f;

        private void Awake()
        {
            m_Dash = GetComponent<CoyoteTime>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Damage"))
            {
                if (m_Dash.isDashing || m_Invulnerable) return;
                TakeDamage(1);
                
            }

            if (other.CompareTag("Death"))
            {
                health = 0;
            }
        }

        private void Update()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
            print("Player Health = " + health);
        }

        public void TakeDamage(int damage)
        {
            if (m_Invulnerable || m_Dash.isDashing) return;
            health -= damage;
            StartCoroutine(Invulnerability());
        }

        private IEnumerator Invulnerability()
        {
            m_Invulnerable = true;
            print("Invulnerable = " + m_Invulnerable);
            yield return new WaitForSeconds(invulnerabilityTimer);
            m_Invulnerable = false;
            print("Invulnerable = " + m_Invulnerable);
        }
    }
}

