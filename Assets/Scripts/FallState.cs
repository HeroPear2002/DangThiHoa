using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : IState
{
    PlayerController playerController;

    public FallState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {
        // code that runs when we first enter the state
        Debug.Log("fall state enter");
        // playerController.anim.CrossFade("Player_Walk", 0f);
        playerController.anim.Play("Player_Fall");
    }
    public void Update()
    {
        // per-frame logic, include condition to transition to a new state
        // Debug.Log("Move state update");
        Debug.Log(playerController.IsGrounded());

        if (playerController.rb.velocity.y <= 0 && playerController.IsGrounded() && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            playerController.stateMachine.TransitionTo(playerController.stateMachine.idleState);
        }
        else if (playerController.IsGrounded())
        {
            playerController.stateMachine.TransitionTo(playerController.stateMachine.moveState);
        }

        //if (playerController.rb.velocity.y <= 0 )
        //{
        //    playerController.stateMachine.TransitionTo(playerController.stateMachine.moveState);
        //}

    }
    public void Exit()
    {
        // code that runs when we exit the state
        Debug.Log("Move state exit");
    }
}
