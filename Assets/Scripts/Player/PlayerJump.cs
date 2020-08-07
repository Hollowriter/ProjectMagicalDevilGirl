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
    Vector3 jumpPosition;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        jumpPosition = PlayerPosition.instance.GetPlayerPosition();
        jumpTimer = 0;
        firstJump = false;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void Jump() 
    {
        if (InputManager.instance.inputDetected()) 
        {
            if (Input.GetKey(InputManager.instance.jump) && jumpTimer < jumpTime && !firstJump) 
            {
                jumpPosition.y += jumpSpeed * Time.deltaTime;
                jumpTimer += Time.deltaTime;
            }
        }
    }

    void GravityActing() 
    {
        if (!Input.GetKey(InputManager.instance.jump) && !PlayerCollisions.instance.GetGrounded() ||
            jumpTimer >= jumpTime && !PlayerCollisions.instance.GetGrounded() ||
            firstJump == true && !PlayerCollisions.instance.GetGrounded()) 
        {
            jumpPosition.y -= Gravity.instance.gravity * Time.deltaTime;
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
        PlayerPosition.instance.SetPlayerPosition(jumpPosition);
    }

    protected override void BehaveSingleton()
    {
        jumpPosition = PlayerPosition.instance.GetPlayerPosition();
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
