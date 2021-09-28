using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPatroll : MonoBehaviour
{
    public float walkSpeed;
    [HideInInspector]
    public bool mustPatrol;

    private bool mustFlip;

    public Rigidbody2D m_Rigidbody2D;
    public Transform GroundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();  
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(GroundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        m_Rigidbody2D.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, m_Rigidbody2D.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
