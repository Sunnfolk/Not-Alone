using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class GetingClaws : StateMachineBehaviour
{
    private PlayerAnimator m_PlayerAnimator;
    private PlayerInput m_Input;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_PlayerAnimator = animator.GetComponent<PlayerAnimator>();
        m_Input = animator.GetComponent<PlayerInput>();
        
        m_PlayerAnimator.enabled = false;
        m_Input.enabled = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_PlayerAnimator.enabled = true;
        m_Input.enabled = true;
    }
}
