using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator m_Animator;
        private PlayerInput m_Input;
        private PlayerJump m_Jump;
        private Rigidbody2D m_Rigidbody2D;
        private CoyoteTime m_Coyote;
        private PlayerAudio m_Audio;
        private PlayerColliders m_Colliders;
        private PlayerDash m_Dash;
        private bool m_falling;
    
        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
            m_Input = GetComponent<PlayerInput>();
            m_Jump = GetComponent<PlayerJump>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Audio = GetComponent<PlayerAudio>();
            m_Coyote = GetComponent<CoyoteTime>();
            m_Colliders = GetComponent<PlayerColliders>();
            m_Dash = GetComponent<PlayerDash>();
        }
    
        private void Update()
        {
            if (m_Input.moveVector.x != 0)
            {
                if (m_Coyote.isDashing) return;
                transform.localScale = new Vector2(m_Input.moveVector.x * 2f, 2f);
            }
            //On ground Run and 
            if (m_Coyote.canCoyote)
            {
                m_falling = false;
                m_Animator.Play(m_Input.moveVector.x != 0 ? "Run" : "Idle");
            }
            else
            {
                if (m_Coyote.isDashing)
                {
                    m_Animator.Play(stateName:"Dash");
                }
                else if (m_Rigidbody2D.velocity.y > 0 )
                {
                    m_Animator.Play(stateName:"Jump");
                }
                else
                {
                    if (!m_falling)
                    {
                        m_Animator.Play(stateName:"StartFalling");
                        //StartCoroutine(FallTimer());
                    }
                    else
                    {
                        Falling();
                    }
                }
            }
        }

        private void Falling()
        {
            if (m_Coyote.canCoyote) return;
            m_falling = true;
            m_Animator.Play(stateName:"Fall");
        } 
        /*
        private IEnumerator FallTimer()
        {
            yield return new WaitForSeconds(0.6f);
            Falling();
        }
        */
    }
}
