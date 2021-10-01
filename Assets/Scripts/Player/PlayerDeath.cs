using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerDeath : MonoBehaviour
    {
        private PlayerHealth m_Health;
        private MaxVelocity m_Velocity;
        [SerializeField] private float velocityTimer = 5;
        private float m_VelocityTime;

        private void Start()
        {
            m_Health = GetComponent<PlayerHealth>();
            m_Velocity = GetComponent<MaxVelocity>();
            m_VelocityTime = velocityTimer;
        }

        private void Update()
        {
            if (m_Health.health <= 0)
            {
                RestartScene();
            }
            /*
            if (m_Velocity.atMaxVelocity)
            {
                print("At max velocity");
                if (m_VelocityTime >= 0)
                {
                    m_VelocityTime -= Time.deltaTime;
                }
                else
                {
                    RestartScene();
                }
            }
            else
            {
                velocityTimer = m_VelocityTime;
            }
            */
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Death"))
            {
                RestartScene();
            }

            if (collider.gameObject.CompareTag("DeathZone"))
            {
                RestartScene();
            }
        }
        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}