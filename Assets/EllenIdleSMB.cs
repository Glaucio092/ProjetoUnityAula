using UnityEngine;

public class EllenIdleSMB : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Garante que a velocidade no Animator seja 0 ao entrar no Idle
        animator.SetFloat("Speed", 0f);
    }
}