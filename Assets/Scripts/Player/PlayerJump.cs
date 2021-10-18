using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CoyoteTime))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerJump : MonoBehaviour
    {
        /* Variables */
        [SerializeField] private float jumpForce;
        public bool isJumping;
        
        /* Timer for LongJump*/
        [SerializeField] private float jumpTimeTimer = 0.5f;
        private float m_JumpTimeCounter;
        
        /* Components */
        private PlayerInput m_Input;
        private CoyoteTime m_Coyote;
        private Rigidbody2D m_Rigidbody2D;
        private Dust m_Dust;
        
        void Awake()
        {
            m_Input = GetComponent<PlayerInput>();
            m_Coyote = GetComponent<CoyoteTime>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Dust = GetComponent<Dust>();
        }

        void Update()
        {
            LongJump();
            if (!isJumping && m_Coyote.canCoyote)
            {
                m_JumpTimeCounter = jumpTimeTimer;
            }
            
            if (m_Input.jump)
            {
                //returns if player isn't grounded
                if (!m_Coyote.canCoyote) return;
                isJumping = true;
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, jumpForce);
                m_Coyote.canCoyote = false;
                //m_Dust.CreateDust();
            }
        }
        
        // If space is held, LongJump is activated making the player jump higher
        private void LongJump()
        {
            if (m_Input.longJump && isJumping)
            {
                //print("LongJump = " + m_Input.longJump);
                //print("IsJumping = " + m_IsJumping);
                if (m_JumpTimeCounter > 0)
                {
                    m_Rigidbody2D.velocity = Vector2.up * jumpForce;
                    m_JumpTimeCounter -= Time.deltaTime;
                    //print("Long Jumping");
                }
                else
                {
                    isJumping = false;
                    //print("JumpTimeCounter = 0");
                }
            }

            if (!m_Input.longJump)
            {
                isJumping = false;
            }
        }
    }
}
