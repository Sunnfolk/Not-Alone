using UnityEngine;

namespace Enemy
{
    public class EnemyDetection : MonoBehaviour
    {
        private Transform player;
        [SerializeField] private float agroRange;
        [SerializeField] private float moveSpeed;

        private Rigidbody2D m_Rigidbody2D;

        void Start()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            // distance to player
            float distToPlayer = Vector2.Distance(transform.position, player.position);
            //print("distToPlayer" + distToPlayer);

            if (distToPlayer < agroRange)
            {
                //chase player
                ChasePlayer();
            }
            else
            {
                //stop Chasing
                StopChasingPlayer();
            }
        }

        
        void ChasePlayer()
            {
                if (transform.position.x < player.position.x)
                {
                    // Enemy is on left, move right
                    m_Rigidbody2D.velocity = new Vector2(moveSpeed, 0);
                    transform.localScale = new Vector3(-1, 1);
                }
                else if (transform.position.x > player.position.x)
                {
                    // Enemy is on Right, move Left
                    m_Rigidbody2D.velocity = new Vector2(-moveSpeed, 0);
                    transform.localScale = new Vector3(1, 1);
                }
            }
        
        void StopChasingPlayer()
        {
            m_Rigidbody2D.velocity = Vector2.zero;
        }
        
        }
    }


