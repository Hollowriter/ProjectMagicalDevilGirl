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
    bool firstJump;
    float jumpPosition;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        jumpPosition = PlayerPosition.instance.GetPlayerPositionY();
        jumpTimer = 0;
        firstJump = false;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void Jump() 
    {
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.JumpIdle ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.JumpLeft ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.JumpRight) 
        {
            jumpPosition = PlayerPosition.instance.GetPlayerPositionY();
            jumpPosition += jumpSpeed * Time.deltaTime;
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= jumpTime) 
            {
                PlayerStates.instance.SetEvent(PlayerStates.Events.FallJump);
            }
        }
    }

    void GravityActing() 
    {
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.FallIdle ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.FallLeft ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.FallRight ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.AirKickIdle ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.AirKickLeft ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.AirKickRight) 
        {
            jumpPosition = PlayerPosition.instance.GetPlayerPositionY();
            jumpPosition -= jumpSpeed * Time.deltaTime;
        }
    }

    void ResetJump() 
    {
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.Idle) 
        {
            jumpTimer = 0;
            firstJump = false;
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
