using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    PlayerController playerController;

    public JumpState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {
        // code that runs when we first enter the state
        Debug.Log("Jump state enter");
        playerController.anim.Play("Player_Jump");

    }
    public void Update()
    {
        // per-frame logic, include condition to transition to a new state
        //Debug.Log("Jump state uodate");
        //if (playerController.rb.velocity.y == 0)
        //{
        //    Debug.Log("transittion to jumpmiddle");
        //    playerController.stateMachine.TransitionTo(playerController.stateMachine.jumpMiddle);
        //}
        if (playerController.rb.velocity.y < 0)
        {
            playerController.stateMachine.TransitionTo(playerController.stateMachine.fallState);
        }
        Debug.Log(playerController.rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.C)){
            playerController.stateMachine.TransitionTo(playerController.stateMachine.skill);
        }
        //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    playerController.stateMachine.TransitionTo(playerController.stateMachine.moveState);
        //}
    }
    public void Exit()
    {
        // code that runs when we exit the state
        Debug.Log("Jump state exit");
    }
}
