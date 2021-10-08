using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dialog Animation State들의 Base 스크립트
/// </summary>
public abstract class DialogStateBase : StateMachineBehaviour
{
    [SerializeField] 
    protected int dataIndex;

    //[SerializeField /*DEBUG*/]
    protected DialogManager dialogManager;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dialogManager = animator.GetComponent<DialogManager>();
        Debug.Assert(dialogManager != null);
    }

}
