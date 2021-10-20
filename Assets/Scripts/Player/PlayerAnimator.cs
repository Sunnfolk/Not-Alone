using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator m_Animator;
        private PlayerInput m_Input;
        
        private Rigidbody2D m_Rigidbody2D;
        private CoyoteTime m_Coyote;
        private bool m_Falling;
        
        
        [SerializeField] private float attackTimer;
        private bool m_Attack1;
        private bool m_Attack2;

        public bool m_Attacking = false;
        

        private void Awake()
        {
            m_Animator = GetComponent<Animator>();
            m_Input = GetComponent<PlayerInput>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Coyote = GetComponent<CoyoteTime>();
        }
    
        private void Update()
        {
            if (attackTimer > 0f)
            {
                attackTimer -= 1 * Time.deltaTime;
            }
            
            
            if (!m_Coyote.canCoyote)
            {
                m_Attack1 = false;
                m_Attack2 = false;
                
            }
            
            if (m_Input.moveVector.x != 0)
            {
                if (m_Coyote.isDashing) return;
                transform.localScale = new Vector2(m_Input.moveVector.x, 1f);
            }
            
            if (m_Input.attack)
            {
                if (m_Coyote.canCoyote)
                {
                    if (attackTimer > 0 || m_Attacking) return;
                    if (!m_Attack1 && !m_Attack2)
                    {
                        m_Animator.Play("Attack1");
                        float time = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
                        attackTimer.Equals(time);
                        m_Attack1 = true;
                    }
                    else if (m_Attack1 && !m_Attack2)
                    {
                        m_Animator.Play("Attack2");
                        float time = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
                        attackTimer.Equals(time);
                        m_Attack2 = true;
                    }
                    else if (m_Attack1 && m_Attack2)
                    {
                        m_Animator.Play("Attack3");
                        float time = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
                        attackTimer.Equals(time);
                        m_Attack1 = false;
                        m_Attack2 = false;
                        
                    }
                }
                else
                {
                    m_Animator.Play("AirAttack");
                }
            }

            if (m_Attacking) return;

            //On ground Run and 
            if (m_Coyote.canCoyote)
            {
                m_Falling = false;
                m_Animator.Play(m_Input.moveVector.x != 0 ? "Run" : "Idle");
            }
            else
            {
                if (m_Input.dash)
                {
                    print("DashAnimation");
                    m_Animator.Play(stateName:"Dash");
                }
                else if (m_Rigidbody2D.velocity.y > 0 )
                {
                    m_Animator.Play(stateName:"Jump");
                }
                else
                {
                    //if (!m_Falling)
                    //{
                        m_Animator.Play(stateName:"Fall");
                        //StartCoroutine(FallTimer());
                    //}
                    /*else
                    {   
                        Falling();
                    } */
                }
            }
        }

        /*private void Falling()
        {
            if (m_Coyote.canCoyote) return;
            m_Falling = true;
            m_Animator.Play(stateName:"Fall");
        }*/

        public void Attacking()
        {
            m_Attacking = m_Attacking == false;
        }
    }
}
