using System.Collections;
using UnityEngine;

namespace Player
{
    
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] public int health = 10;

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
                Damage();
                
            }

            if (other.CompareTag("Death"))
            {
                health = 0;
            }
        }

        private void Update()
        {
            print("Player Health = " + health);
            
        }

        private void Damage()
        {
            health -= 1;
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
