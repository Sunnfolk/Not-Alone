using Player;
using UnityEngine;

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
    
    private void Start()
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

    // Update is called once per frame
    void Update()
    {
        if (m_Input.moveVector.x != 0)
        {
            transform.localScale = new Vector2(m_Input.moveVector.x * 1.5f, 1.5f);
        }
        //On ground Run and 
        if (m_Coyote.canCoyote)
        {
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
                m_Animator.Play(stateName:"Fall");
            }
        }
        

    }
}
