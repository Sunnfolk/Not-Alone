using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public GameObject damageTrigger;
    
    public void ActivateTrigger()
    {
        damageTrigger.SetActive(true);
    }

    public void DeActivateTrigger()
    {
        damageTrigger.SetActive(false);
    }

}
