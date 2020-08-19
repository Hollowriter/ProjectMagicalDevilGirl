using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : SingletonBase<PlayerJump>
{
    [SerializeField]
    int jumpSpeed;
    [SerializeField]
    float jumpTime;
    float jumpTimer;
    float jumpPosition;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        jumpPosition = PlayerPosition.instance.GetPlayerPositionY();
        jumpTimer = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void Jump() 
    {
        if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.JumpIdle ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.JumpLeft ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.JumpRight) 
        {
            jumpPosition = PlayerPosition.instance.GetPlayerPositionY();
            jumpPosition += jumpSpeed * Time.deltaTime;
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= jumpTime) 
            {
                PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.FallJump);
            }
        }
    }

    void GravityActing() 
    {
        if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.FallIdle ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.FallLeft ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.FallRight ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickIdle ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickLeft ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickRight) 
        {
            jumpPosition = PlayerPosition.instance.GetPlayerPositionY();
            jumpPosition -= Gravity.instance.gravity * Time.deltaTime;
        }
    }

    void ResetJump() 
    {
        if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.Idle) 
        {
            jumpTimer = 0;
        }
    }

    void ApplyJump() 
    {
        PlayerPosition.instance.SetPlayerPositionY(jumpPosition);
    }

    protected override void BehaveSingleton()
    {
        Jump();
        GravityActing();
        ApplyJump();
        ResetJump();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
