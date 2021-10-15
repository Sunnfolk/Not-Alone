using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    public ParticleSystem dust;
    public ParticleSystem attack;
    public ParticleSystem dash;
    public void CreateDust()
    {
        dust.Play();
    }

    public void CreateAttackParticles()
    {
        attack.Play();
    }

    public void CreateDashTrails()
    {
        print("Added Trail");
        dash.Play();
    }
}
