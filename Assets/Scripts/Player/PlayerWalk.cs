using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerWalk : MonoBehaviour
    {
        /* Speeds */
        [SerializeField] private float walkSpeed = 7f;
        [SerializeField] private float runSpeed = 10f;
        
        /* Components */
        private PlayerInput m_Input;
        private Rigidbody2D m_Rigidbody2D;
    
        private void Start()
        {
            m_Input = GetComponent<PlayerInput>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            //Run (Checks if Shift is held)
            if (m_Input.run)
            {
                m_Rigidbody2D.velocity = new Vector2(m_Input.moveVector.x * runSpeed, m_Rigidbody2D.velocity.y);
            }
            //Walk (Checks to see that Shift isn't held)
            if (!m_Input.run)
            {
                m_Rigidbody2D.velocity = new Vector2(m_Input.moveVector.x * walkSpeed, m_Rigidbody2D.velocity.y);
            }
        }
    }
}
