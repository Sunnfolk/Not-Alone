using UnityEngine;


namespace Player
{
    [RequireComponent(typeof(PlayerColliders))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerJump))]
    public class CoyoteTime : MonoBehaviour
    {
        private PlayerColliders m_Colliders;
        private Rigidbody2D m_Rigidbody2D;
        private PlayerJump m_Jump;
        private PlayerDash m_Dash;
        private PlayerWalk m_Walk;
        private PlayerInput m_Input;
        [HideInInspector] public bool hasDashed;
        [HideInInspector] public bool isDashing;
            
        [HideInInspector] public bool canCoyote;
        
        /*Coyote Timer*/
        [SerializeField] private float coyoteTime = 0.2f;
        private float m_CoyoteTimeCounter;
        
        
        void Awake()
        {
            m_Colliders = GetComponent<PlayerColliders>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Jump = GetComponent<PlayerJump>();
            m_Dash = GetComponent<PlayerDash>();
            m_Walk = GetComponent<PlayerWalk>();
            m_Input = GetComponent<PlayerInput>();
        }
    
        void Update()
        {
            print("CanCoyote = " + canCoyote);
            if (m_Colliders.IsGrounded())
            {
                canCoyote = true;
                m_CoyoteTimeCounter = coyoteTime;
            }
            else if (!m_Colliders.IsGrounded() && m_Rigidbody2D.velocity.y <= 0)
            {
                m_CoyoteTimeCounter -= Time.deltaTime;
            }
            
            if (m_CoyoteTimeCounter < 0 || m_Jump.isJumping)
            {
                canCoyote = false;
               
            }
            if (canCoyote)
            {
                hasDashed = false;
                isDashing = false;
            }

            if (!hasDashed)
            {
                m_Input.enabled = true;
                m_Walk.enabled = true;
                m_Jump.enabled = true;
            }
            
            m_Dash.enabled = !canCoyote;
        }
    }
}
