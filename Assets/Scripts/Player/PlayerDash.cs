using System.Collections;
using UnityEngine;
using WorldSystems;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerDash : MonoBehaviour

    {
        private PlayerJump m_Jump;
        private CoyoteTime m_Coyote;
        private PlayerWalk m_Walk;
        private Rigidbody2D m_Rigidbody2D;
        private PlayerInput m_Input;
        private Dust m_Dust;

        [SerializeField] private float normalGravity = 5f;
        [SerializeField] private float dashSpeed = 10f;

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Input = GetComponent<PlayerInput>();
            m_Walk = GetComponent<PlayerWalk>(); 
            m_Coyote = GetComponent<CoyoteTime>();
            m_Jump = GetComponent<PlayerJump>();
            m_Dust = GetComponent<Dust>();
        }

        private void Update()
        {
            if (m_Coyote.canCoyote) return;
            /*if (m_Input.dash)
            {
                if (m_Coyote.hasDashed || m_Coyote.isDashing) return;
                Dash();
            }*/
        }

        public void Dash()
        {
            
            m_Coyote.hasDashed = true;
            m_Walk.enabled = false;
            m_Jump.enabled = false;
            m_Input.enabled = false;

            if (m_Input.moveVector.magnitude >= 1)
            {
               m_Input.moveVector = m_Input.moveVector.normalized;
            }
            
            
            Vector2 velocity = new Vector2(m_Input.moveVector.x * dashSpeed, -m_Input.moveVector.y * dashSpeed * 0.6f);
            m_Rigidbody2D.velocity = velocity;
            
            m_Dust.CreateDashTrails();
            
            StartCoroutine(DashWait());
        }
        
        private IEnumerator DashWait()
        {
            StartCoroutine(GroundDash());
            m_Rigidbody2D.gravityScale = 0f;
            m_Coyote.isDashing = true;
            yield return new WaitForSeconds(0.3f);
            m_Rigidbody2D.gravityScale = normalGravity;
            
            m_Input.enabled = true;
            m_Walk.enabled = true;
            m_Jump.enabled = true;
            
            m_Coyote.isDashing = false;
            
        }
        IEnumerator GroundDash()
        {
            yield return new WaitForSeconds(.15f);
            if (m_Coyote.canCoyote)
                m_Coyote.hasDashed = false;
        }
    }
}

