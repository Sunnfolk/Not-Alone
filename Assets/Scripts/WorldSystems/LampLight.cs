using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LampLight : MonoBehaviour
{
    public Light _Light;
    private void OnTriggerEnter(Collider other)
    {
        _Light.enabled = true;
    }
}
