using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlipper : MonoBehaviour
{
    public Transform player;
    private Spikes m_Spikes;
    public bool isFlipped;

    private void Start()
    {
        m_Spikes = GetComponent<Spikes>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void LookAtPlayer()
    {
        if (m_Spikes.spikeLength < m_Spikes.spike.Length) return;
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x  && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x  && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }
}
