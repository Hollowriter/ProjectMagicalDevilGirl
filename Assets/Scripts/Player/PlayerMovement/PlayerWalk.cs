using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : SingletonBase<PlayerWalk>
{
    [SerializeField]
    int characterSpeed;
    float newPlayerPositionX;
    bool direction;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        newPlayerPositionX = PlayerPosition.instance.GetPlayerPositionX();
        direction = true;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetDirection(bool _direction)
    {
        direction = _direction;
    }

    public bool GetDirection()
    {
        return direction;
    }

    void WalkRight()
    {
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.WalkingRight ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.JumpRight ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.FallRight)
        {
            newPlayerPositionX += characterSpeed * Time.deltaTime;
            ApplyMovement();
            SetDirection(true);
        }
    }

    void WalkLeft()
    {
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.WalkingLeft ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.JumpLeft ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.FallLeft)
        {
            newPlayerPositionX -= characterSpeed * Time.deltaTime;
            ApplyMovement();
            SetDirection(false);
        }
    }

    void ApplyMovement() 
    {
        PlayerPosition.instance.SetPlayerPositionX(newPlayerPositionX);
    }

    void MovementUpdate()
    {
        newPlayerPositionX = PlayerPosition.instance.GetPlayerPositionX();
        WalkLeft();
        WalkRight();
    }

    protected override void BehaveSingleton()
    {
        MovementUpdate();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
