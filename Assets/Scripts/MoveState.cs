using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    PlayerController playerController;

    public MoveState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {
        // code that runs when we first enter the state
        Debug.Log("Move state enter");
        playerController.anim.Play("Player_Walk");

    }
    public void Update()
    {
        // per-frame logic, include condition to transition to a new state
        // Debug.Log("Move state update");
        if (Input.GetKeyUp(KeyCode.Space) && playerController.IsGrounded())
        {
            playerController.stateMachine.TransitionTo(playerController.stateMachine.jumpState);
        }
        Debug.Log("axis " + playerController.xAxis);
        Debug.Log("x : " + playerController.rb.velocity.x);
        if (playerController.rb.velocity.x == 0 )
        {
            playerController.stateMachine.TransitionTo(playerController.stateMachine.idleState);
        }
        if (playerController.rb.velocity.y < 0)
        {
            playerController.stateMachine.TransitionTo(playerController.stateMachine.fallState);
        }

    }
    public void Exit()
    {
        // code that runs when we exit the state
        Debug.Log("Move state exit");
    }
}
