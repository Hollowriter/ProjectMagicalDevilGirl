using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : SingletonBase<PlayerJump> // Nota: Hacer funciones para permitir saltos en parabola si hay una tecla apretada al hacer el salto.
{ // Y que la direccion no se modifique por input del jugador si este esta aun en el aire.
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
            PlayerStates.instance.GetState() == (int)PlayerStates.States.FallRight) 
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
