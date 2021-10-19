using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckpointLight : MonoBehaviour
{

    public GameObject lightThing;
    
    
    
    void Start()
    {
        lightThing.SetActive(false);
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lightThing.SetActive(true);
        }
    }
}
