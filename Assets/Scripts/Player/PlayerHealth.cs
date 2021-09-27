using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int health = 10;
        private Rigidbody2D m_Rigidbody2D;

        private void Awake()
        { 
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }
        /*
        Update()
        {
            if ()
            {
                
            }
        }
        */
        
    }
}
