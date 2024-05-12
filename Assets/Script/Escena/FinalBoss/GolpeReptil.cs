using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeReptil : StateMachineBehaviour
{
    private Transform player;
    private MovBoss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<MovBoss>();
        player = boss.jugador;
        boss.MirarJugador();
        boss.SuperAttack();
    }
}
