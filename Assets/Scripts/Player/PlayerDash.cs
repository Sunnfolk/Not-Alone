using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerColliders))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerDash : MonoBehaviour

    {
        private PlayerJump m_Jump;
        private CoyoteTime m_Coyote;
        private PlayerWalk m_Walk;
        private PlayerColliders m_Colliders;
        private Rigidbody2D m_Rigidbody2D;
        private PlayerInput m_Input;
        private bool m_HasDashed;
        [HideInInspector] public bool isDashing;
        [SerializeField] private float normalGravity = 5f;
        [SerializeField] private float dashSpeed = 10f;

        private void Awake() 
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Colliders = GetComponent<PlayerColliders>();
            m_Input = GetComponent<PlayerInput>();
            m_Walk = GetComponent<PlayerWalk>();
            m_Coyote = GetComponent<CoyoteTime>();
            m_Jump = GetComponent<PlayerJump>();

        }

        private void Update()
        {
            if (m_Colliders.IsGrounded())
            {
                m_HasDashed = false;
                isDashing = false;
            }

            if (!m_HasDashed)
            {
                m_Input.enabled = true;
                m_Walk.enabled = true;
                m_Jump.enabled = true;
            }

            if (m_Input.dash)
            {
                if (m_HasDashed || isDashing) return;
                Dash();
                print("Dash = " + m_HasDashed);
            }
        }

        private void Dash()
        {
            if (m_Coyote.canCoyote) return;
            if (m_Input.moveVector == Vector2.zero) return;
            m_HasDashed = true;
            m_Walk.enabled = false;
            m_Jump.enabled = false;
            m_Input.enabled = false;
            
                
            Vector2 velocity = new Vector2(m_Input.moveVector.x * dashSpeed, -m_Input.moveVector.y * dashSpeed * 0.6f);
            m_Rigidbody2D.velocity = velocity;

            m_Rigidbody2D.gravityScale = 0f;
            StartCoroutine(DashWait());
        }
        
        private IEnumerator DashWait()
        {
            
            isDashing = true;
            yield return new WaitForSeconds(0.3f);
            m_Rigidbody2D.gravityScale = normalGravity;
            isDashing = false;
            m_Input.enabled = true;
            m_Walk.enabled = true;
            m_Jump.enabled = true;
        }
    }
}

