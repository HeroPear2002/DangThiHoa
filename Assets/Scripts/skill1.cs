using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill1 : IState
{
    PlayerController playerController;

    public skill1(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {
        // code that runs when we first enter the state
        //Debug.Log("Move state enter");
    }
    public void Update()
    {
        // per-frame logic, include condition to transition to a new state
        // Debug.Log("Move state update");
    }
    public void Exit()
    {
        // code that runs when we exit the state
        //Debug.Log("Move state exit");
    }
}
