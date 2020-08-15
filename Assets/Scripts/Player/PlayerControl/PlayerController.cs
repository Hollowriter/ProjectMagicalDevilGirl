using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonBase<PlayerController>
{
    bool attackPressed;
    bool jumpPressed;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        attackPressed = false;
        jumpPressed = false;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void PressedLeft() 
    {
        if (Input.GetKey(InputManager.instance.walkLeft)) 
        {
            PlayerStates.instance.SetEvent(PlayerStates.Events.WalkLeft);
        }
    }

    void PressedRight() 
    {
        if (Input.GetKey(InputManager.instance.walkRight)) 
        {
            PlayerStates.instance.SetEvent(PlayerStates.Events.WalkRight);
        }
    }

    void PressedJump() 
    {
        if (Input.GetKey(InputManager.instance.jump) && !jumpPressed) 
        {
            PlayerStates.instance.SetEvent(PlayerStates.Events.Jump);
            jumpPressed = true;
        }
    }

    void PressedAttack() 
    {
        if (Input.GetKey(InputManager.instance.attack) && !attackPressed) 
        {
            PlayerStates.instance.SetEvent(PlayerStates.Events.Punch);
            attackPressed = true;
        }
    }

    void StopPressing() 
    {
        if (Input.GetKeyUp(InputManager.instance.walkLeft) || Input.GetKeyUp(InputManager.instance.walkRight)) 
        {
            PlayerStates.instance.SetEvent(PlayerStates.Events.Stop);
        }
        if (Input.GetKeyUp(InputManager.instance.attack)) 
        {
            attackPressed = false;
        }
        if (Input.GetKeyUp(InputManager.instance.jump)) 
        {
            jumpPressed = false;
        }
    }

    void CheckControls() 
    {
        if (InputManager.instance.inputDetected()) 
        {
            PressedLeft();
            PressedRight();
            PressedJump();
            PressedAttack();
        }
        StopPressing();
    }

    protected override void BehaveSingleton()
    {
        CheckControls();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
