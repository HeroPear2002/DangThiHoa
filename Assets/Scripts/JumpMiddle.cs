using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMiddle : IState
{
    PlayerController playerController;

    public JumpMiddle(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {
        // code that runs when we first enter the state
        Debug.Log("jump middle state enter");
        // playerController.anim.CrossFade("Player_Walk", 0f);
        playerController.anim.Play("Player_JumpMiddle");
    }
    public void Update()
    {
        // per-frame logic, include condition to transition to a new state
        // Debug.Log("Move state update");
        //if (playerController.rb.velocity.y <= 0 && playerController.IsGrounded())
        //{
        //    playerController.stateMachine.TransitionTo(playerController.stateMachine.idleState);
        //}
        Debug.Log(playerController.rb.velocity.y);
        if (playerController.rb.velocity.y <= 0)
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
