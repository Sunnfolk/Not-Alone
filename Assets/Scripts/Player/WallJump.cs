using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PlayerJump))]
    [RequireComponent(typeof(PlayerInput))]
    public class WallJump : MonoBehaviour
    {
        
        public float walkSpeed;
        private PlayerInput m_Input;
        public float jumpSpeed;
        private Rigidbody2D m_Rigidbody2D;
        public LayerMask groundMask;
        private bool isGrounded;
        private bool isTouchingLeft;
        private bool isTouchingRight;
        private bool wallJumping;
        private float touchingLeftOrRight;
        private bool wallSliding;
        public float slideSpeed = 5;
        
    

        //art is called before the first frame update
        void Start()
        {
            m_Input = GetComponent<PlayerInput>();
            m_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }
        // Update is called once per frame
        void Update()
        {
            var position = gameObject.transform.position;
            isGrounded = Physics2D.OverlapBox(new Vector2((position.x), (float) (position.y - 0.725)),
                new Vector2(0.15f, 0.8f), 0f, groundMask);
        
            isTouchingLeft = Physics2D.OverlapBox(new Vector2( (position.x - 0.5f), (position.y)),
                new Vector2(0.2f, 1.25f), 0f, groundMask);
            

            isTouchingRight = Physics2D.OverlapBox(new Vector2( (position.x + 0.5f), (position.y)),
                new Vector2(0.2f, 1.25f), 0f, groundMask);
            
            

            if (isTouchingLeft)
            {
                touchingLeftOrRight = 1;
            }
            else if (isTouchingRight)
            {
                touchingLeftOrRight = -1;
            }

            if (m_Input.jump && (isTouchingRight || isTouchingLeft) && !isGrounded)
            {
                wallJumping = true;
                Invoke(nameof(SetWallJumpFalse), 0.08f);
            }

            if (wallJumping)
            {
                m_Rigidbody2D.velocity = new Vector2(walkSpeed * touchingLeftOrRight,jumpSpeed);
            }

            if (isTouchingLeft || isTouchingRight && !isGrounded)
            {
                wallSliding = true;
                WallSlide();
            }
            

           
            
            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            var position = gameObject.transform.position;
            Gizmos.DrawCube(new Vector2(position.x,  (float) (position.y - 0.725)),
                new Vector2(0.9f, 0.2f));
            
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(new Vector2(position.x - 0.5f, position.y),
                new Vector2(0.25f, 1.25f));
            Gizmos.DrawCube(new Vector2( (position.x + 0.5f), (position.y)),
                new Vector2(0.25f, 1.25f));
           
        }

        private void SetWallJumpFalse()
        {
            wallJumping = false;
        }

        private void WallSlide()
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -slideSpeed);
        }

        
        }
    }
    
    

