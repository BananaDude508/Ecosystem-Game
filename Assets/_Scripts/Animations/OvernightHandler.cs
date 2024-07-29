using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static DayNightManager;

public class OvernightHandler : StateMachineBehaviour
{
    GameObject[] elementsToHide;

    private void Awake()
    {
        elementsToHide = GameObject.FindGameObjectsWithTag("PlayerHideOvernight");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sleeping = true;

        if (stateInfo.IsName("Overnight"))
            foreach (var element in elementsToHide)
                element.SetActive(false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		sleeping = false;

        if (stateInfo.IsName("Overnight"))
            foreach (var element in elementsToHide)
                element.SetActive(true);
    }
}
