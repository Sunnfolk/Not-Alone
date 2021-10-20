using UnityEngine;

namespace Player
{
    public class NewPlayerAnimation : MonoBehaviour
    {
        // Enum States
        public enum State
        {
            Grounded,
            Air,
            Dashing
        };
        public State states;
    
        // Components
        private PlayerInput m_Input;
        private Rigidbody2D m_Rigidbody2D;
        private CoyoteTime m_Coyote;
        private PlayerDash m_Dash;
        private Animator m_Animator;
        private PlayerAudio m_Audio;
        private Dust m_Particle;
    
        void Start()
        {
            states = State.Grounded;
        
            // Components
            m_Input = GetComponent<PlayerInput>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Coyote = GetComponent<CoyoteTime>();
            m_Dash = GetComponent<PlayerDash>();
            m_Animator = GetComponent<Animator>();
            m_Audio = GetComponent<PlayerAudio>();
            m_Particle = GetComponent<Dust>();
        }
        // Attack Variables
        private float m_AttackTimer;
        private bool m_Attack1;
        private bool m_Attack2;
        private bool m_Attacking;
        
        private void Update()
        {
            // States
            switch (states)
            {
                case State.Grounded:
                    Ground();
                    break;
                case State.Air:
                    Air();
                    break;
                case State.Dashing:
                    Dashing();
                    break;
            }
            
            //Attacks
            if (m_AttackTimer > 0f)
            {
                m_AttackTimer -= Time.deltaTime;
                m_Attacking = true;
            }
            else
            {
                m_Attacking = false;
            }
        }

        private void Ground()
        {
            print("States = " + states);
        
            //State Switch -> Air
            if (m_Input.jump)
            {
                m_Audio.JumpAudio();
                states = State.Air;
                
                m_Particle.CreateDust();
                
                m_AttackTimer = 0f;
            }
            else if (m_Rigidbody2D.velocity.y < 0 && !m_Coyote.canCoyote)
            {
                states = State.Air;
                m_AttackTimer = 0f;
            }
            
            // Ground Attacks
            if (m_Input.attack)
            {
                if (m_AttackTimer > 0 || m_Attacking) return;
                if (!m_Attack1 && !m_Attack2)
                {
                    print("Attack1");
                    m_Animator.Play("Attack1");
                    float time = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
                    m_AttackTimer = 0.5f * time;
                    m_Attack1 = true;
                }
                else if (m_Attack1 && !m_Attack2)
                {
                    print("Attack2");
                    m_Animator.Play("Attack2");
                    float time = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
                    m_AttackTimer = 0.5f * time;
                    m_Attack2 = true;
                }
                else if (m_Attack1 && m_Attack2)
                {
                    print("Attack3");
                    m_Animator.Play("Attack3");
                    float time = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
                    m_AttackTimer = 0.5f * time;
                    m_Attack1 = false;
                    m_Attack2 = false;
                }
            }
            if (!m_Attacking)
            {
                // Run and Idle
                m_Animator.Play(m_Input.moveVector.x != 0 ? "Run" : "Idle");
            }
            
            // Player Turnaround
            if (m_Input.moveVector.x != 0)
            {
                transform.localScale = new Vector2(m_Input.moveVector.x, 1f);
            }
        }

        private void Air()
        {
            print("States = " + states);
        
            //State Switch -> Ground
            if (m_Coyote.canCoyote)
            {
                m_Animator.Play("Landing");
                m_Audio.LandingAudio();
                states = State.Grounded;
                
                m_Particle.CreateDust();
                
                m_AttackTimer = 0f;
            }

            //State Switch -> Dash
            if (m_Input.dash)
            {
                if (m_Coyote.hasDashed || m_Coyote.isDashing) return;
                if (m_Input.moveVector.y > 0f) return;
                if (m_Coyote.hasDashed || m_Coyote.canCoyote) return;
                if (m_Input.moveVector == Vector2.zero) return;
                
                m_AttackTimer = 0f;
                
                m_Audio.DashingAudio();
                m_Animator.Play("Dash");
                m_Dash.Dash();
                states = State.Dashing;
            }
            
            // Player Turnaround
            else if (m_Input.moveVector.x != 0)
            {
                transform.localScale = new Vector2(m_Input.moveVector.x, 1f);
            }
            
            // Jump attacks and Ground Attack reset
            if (m_Input.attack)
            {
                m_Animator.Play("AirAttack");
                float time = m_Animator.GetCurrentAnimatorClipInfo(0).Length;
                m_AttackTimer = 0.5f * time;
            }
            m_Attack1 = false;
            m_Attack2 = false;
            
            if (m_Attacking) return;
            
            // Jumping then Falling
            if (m_Rigidbody2D.velocity.y > 0 )
            {
                m_Animator.Play(stateName:"Jump");
            }
            else
            {
                m_Animator.Play(stateName:"Fall");
            }
        
        }

        private void Dashing()
        {
            print("States = " + states);

            //State Switch -> Air
            if (!m_Coyote.isDashing)
            {
                states = State.Air;
                
                m_AttackTimer = 0f;
            }
        }
    }
}