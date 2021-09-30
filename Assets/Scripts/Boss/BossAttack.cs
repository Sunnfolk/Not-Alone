using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int attackDamageBite = 1;
    public int attackDamageSlam = 2;
    public Vector2 attackOffsetBite;
    public Vector2 attackOffsetSlam;
    public float biteRange;
    public float slamRange;
    [SerializeField] private float attackRangeBite = 20;
    [SerializeField] private float attackRangeSlam = 8;

    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody2D;
    
    private Transform m_Player;

    public LayerMask attackMask;

    public void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Math.Abs(Vector2.Distance(m_Player.position, m_Rigidbody2D.position) - attackRangeBite) < 2f)
        {
            m_Animator.SetTrigger("Bite");
            print("activated Bite");
        }
        else if (Math.Abs(Vector2.Distance(m_Player.position, m_Rigidbody2D.position) - attackRangeSlam) < 2f)
        {
            m_Animator.SetTrigger("Slam");
            m_Animator.ResetTrigger("Bite");
        }
    }

    
    public void Bite()
    {
        Vector3 position = transform.position;
        position += transform.right * attackOffsetBite.x;
        position += transform.up * attackOffsetBite.y;
        Collider2D collider2D = Physics2D.OverlapCircle(position, biteRange, attackMask);

        if (collider2D != null)
        {
            collider2D.GetComponent<PlayerHealth>().TakeDamage(attackDamageBite);
        }

    }

    public void Slam()
    {
        Vector3 position = transform.position;
        position += transform.right * attackOffsetSlam.x;
        position += transform.up * attackOffsetSlam.y;
        Collider2D collider2D = Physics2D.OverlapCircle(position, slamRange, attackMask);

        if (collider2D != null)
        {
            collider2D.GetComponent<PlayerHealth>().TakeDamage(attackDamageSlam);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Bite
        Vector3 position = transform.position;
        position += transform.right * attackOffsetBite.x;
        position += transform.up * attackOffsetBite.y;
        Gizmos.DrawWireSphere(position, biteRange);
        
        //Slam
        Vector3 position1 = transform.position;
        position1 += transform.right * attackOffsetSlam.x;
        position1 += transform.up * attackOffsetSlam.y;
        Gizmos.DrawWireSphere(position1, slamRange);
    }
}
