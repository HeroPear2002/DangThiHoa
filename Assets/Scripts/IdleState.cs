using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    PlayerController playerController;

    public IdleState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {
        // code that runs when we first enter the state
        Debug.Log("idle state enter");
        playerController.anim.Play("Player_Idle");

    }
    public void Update()
    {
        // per-frame logic, include condition to transition to a new state
       // Debug.Log(" idle state update");
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerController.stateMachine.TransitionTo(playerController.stateMachine.jumpState);
        }
        //if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        //{ 
        //    playerController.stateMachine.TransitionTo(playerController.stateMachine.moveState);
        //}
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerController.stateMachine.TransitionTo(playerController.stateMachine.moveState);
        }
    }
    public void Exit()
    {
        // code that runs when we exit the state
        Debug.Log("idle state exit");
    }
}
