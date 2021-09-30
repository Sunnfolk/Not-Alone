using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleporter : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private Transform m_Player;
    private float distance;
    [SerializeField] private float maxDistance = 40;
    [SerializeField] private float teleportDistance;
    
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        distance = Vector2.Distance(m_Player.position, transform.position);
  

        if ((m_Player.position.x > transform.position.x) && distance > maxDistance)
        {
           print("We are Left");
           Vector2 target = new Vector2(m_Player.position.x + teleportDistance, transform.position.y);
           transform.position = target;
        }
        else if ((m_Player.position.x < transform.position.x) && distance > maxDistance)
        {
            print("We are Right");
            Vector2 target = new Vector2(m_Player.position.x + -teleportDistance, transform.position.y);
            transform.position = target;
        }
    }
}
