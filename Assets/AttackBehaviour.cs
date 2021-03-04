using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    [Tooltip("RightAttacking or something else")]
    public string weaponPart = "RightAttacking";
    public float startTime = 0;
    public float endTime = 1;

    public bool cameraShake = false;

    private bool exited = false;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        exited = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (exited) { return; }

        if (stateInfo.normalizedTime % 1 >= startTime && stateInfo.normalizedTime % 1 <= endTime)
        {
            if (animator.GetBool(weaponPart) == false) 
                {
                animator.SetBool(weaponPart, true);

                if (cameraShake)
                {
                  
                }
            }
           
        }
        else {
            animator.SetBool(weaponPart, false);

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(weaponPart, false);
        exited = true;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
