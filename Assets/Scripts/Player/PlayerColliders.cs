using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerColliders : MonoBehaviour
    {
        // Chooses the layer which Grounded gets activated on
        [SerializeField] private LayerMask whatIsGround;
        
        // Lenght of the raycast
        [SerializeField] private float rayCastLenght = 0.7f;
        
        /* Components */
        private Rigidbody2D m_Rigidbody2D;
        
        void Awake()
        {
            GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            IsGrounded();
        }
        
        // One Middle Raycast checking if it collides with whatIsGround, if it collides it returns as true
        public bool IsGrounded()
        {
            var position = transform.position;
            Debug.DrawRay(position, Vector2.down, new Color(1f, 0.03f, 0f));
            RaycastHit2D hit2D = Physics2D.Raycast(position, Vector2.down, rayCastLenght, whatIsGround);
            /* debug to check if grounded gets activated */
            //print("IsGrounded = " + (hit2D.collider != null)); 
            return hit2D.collider != null;
        }
    }
}
