using UnityEngine;

namespace Player
{
    
    public class WallSlide : MonoBehaviour
    {
        /*
        private Rigidbody2D m_Rigidbody2D;
        public LayerMask groundMask;

        private bool isGrounded;
        private bool isTouchingLeft;
        private bool isTouchingRight;
        private bool wallJumping;
        private float touchingLeftOrRight;
        private bool wallSliding;
        private float slideSpeed;
        // Start is called before the first frame update
        void Start()
        {
            m_Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            var position = gameObject.transform.position;
            isGrounded = Physics2D.OverlapBox(new Vector2((position.x), (float) (position.y - 9)),
                new Vector2(0.15f, 0.8f), 0f, groundMask);
        
            isTouchingLeft = Physics2D.OverlapBox(new Vector2( (position.x - 0.5f), (position.y)),
                new Vector2(0.2f, 1.25f), 0f, groundMask);
            

            isTouchingRight = Physics2D.OverlapBox(new Vector2( (position.x + 0.325f), (position.y)),
                new Vector2(0.2f, 1.25f), 0f, groundMask);
            
            if (isTouchingLeft || isTouchingRight && !isGrounded)
            {
                wallSliding = true;
                WallSliding();
            }
        }
        private void WallSliding()
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -slideSpeed);
        }
        */
    }
}
