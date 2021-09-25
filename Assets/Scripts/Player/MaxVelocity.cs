using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerColliders))]
    public class MaxVelocity : MonoBehaviour
    {
        [SerializeField] private float maxVelocity = 30f;
        
        private Rigidbody2D m_Rigidbody2D;
        private PlayerColliders m_Colliders;
        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            m_Colliders = GetComponent<PlayerColliders>();
        }

        private void Update()
        {
            SetMaxVelocity();
        }

        private void SetMaxVelocity()
        {
            if (m_Colliders.IsGrounded()) return;
            if (!(m_Rigidbody2D.velocity.y < maxVelocity * -1f)) return;
            var velocity = m_Rigidbody2D.velocity;
            velocity = new Vector2(velocity.x, maxVelocity * -1f);
            m_Rigidbody2D.velocity = velocity;
            //print("PlayerSpeed = " + velocity);
        }
    }
}
