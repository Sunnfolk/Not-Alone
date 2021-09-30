using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spikes : MonoBehaviour
{
    [SerializeField] public GameObject[] spike;
    public List<float> timers;

    private void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            foreach (var Ga  in spike)
            {
                Ga.SetActive(true);
                
                gameObject.TryGetComponent(out Animator anim);
                anim.Play("SpikeAnimation");
                float time = anim.GetCurrentAnimatorClipInfo(0).Length;
                timers.Add(time);
            }
        }

        for (int i = 0; i < timers.Count; i++)
        {
            if (timers[i] > 0f)
            {
                timers[i] -= 1 * Time.deltaTime;
            }
            else
            {
                print(timers);
                spike[i].SetActive(false);
            }
        }
    }
}
