using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BossIdle : StateMachineBehaviour
{
    public float timer;
    private static readonly int Walk = Animator.StringToHash("Walk");
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 2f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger(Walk);
        }
        else
        {
            timer -= Time.deltaTime;
        }
            
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
