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

    public void Jump() 
    {
        if (jumpTimer < jumpTime && !firstJump) 
        {
            jumpPosition = PlayerPosition.instance.GetPlayerPositionY();
            jumpPosition += jumpSpeed * Time.deltaTime;
            jumpTimer += Time.deltaTime;
        }
    }

    void GravityActing() 
    {
        if (!Input.GetKey(InputManager.instance.jump) && !PlayerCollisions.instance.GetGrounded() ||
            jumpTimer >= jumpTime && !PlayerCollisions.instance.GetGrounded() ||
            firstJump == true && !PlayerCollisions.instance.GetGrounded()) 
        {
            jumpPosition = PlayerPosition.instance.GetPlayerPositionY();
            jumpPosition -= jumpSpeed * Time.deltaTime;
            firstJump = true;
        }
    }

    void ResetJump() 
    {
        if (PlayerCollisions.instance.GetGrounded()) 
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
        GravityActing();
        ApplyJump();
        ResetJump();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
