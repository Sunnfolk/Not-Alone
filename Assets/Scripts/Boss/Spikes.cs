using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spikes : MonoBehaviour
{
    [SerializeField] public GameObject[] spike;
    public List<float> timers;
    private float timerTime = 0;
    public int spikeLength = 0;

    public bool go;
    public Animator _boss;

    private void Update()
    {
        if (spikeLength < spike.Length)
        {
            if (timerTime >= 0 && go)
            {
                timerTime -= 1 * Time.deltaTime;

                print("FinishCount");
            }
            else if (timerTime <= 0 && go)
            {
                spikeLength++;
                print("Restart");
                AnimationSetTimer();
            }
        }
        else if (spikeLength >= spike.Length && timerTime <= 0)
        {
            go = false;
            foreach (var obj in spike)
            {
                obj.SetActive(false);
                
            }
            print("I won't work because im POOOOR");
            _boss.SetTrigger("Spikes");
        }
    }

    private void StartSpikes()
    {
        spikeLength = 0;
        AnimationSetTimer();
        go = true;
       
    }

    private void AnimationSetTimer()
    {
        spike[spikeLength].SetActive(true);
        spike[spikeLength].TryGetComponent(out Animator anim);
        anim.Play("SpikeAnimation");
        
        timerTime = anim.GetCurrentAnimatorClipInfo(0).Length;
        
        if (spikeLength >= spike.Length-1)
        {
            timerTime += 0.7f;
        }
        else
        {
            timerTime /= 4f;
        }
    }
}
