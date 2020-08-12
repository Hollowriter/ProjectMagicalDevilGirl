using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonBase<PlayerController>
{
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
        if (Input.GetKey(InputManager.instance.jump)) 
        {
            PlayerStates.instance.SetEvent(PlayerStates.Events.Jump);
        }
    }

    void PressedAttack() 
    {
        if (Input.GetKey(InputManager.instance.attack)) 
        {
            PlayerStates.instance.SetEvent(PlayerStates.Events.Punch);
        }
    }

    void StopPressing() 
    {
        if (Input.GetKeyUp(InputManager.instance.walkLeft) || Input.GetKeyUp(InputManager.instance.walkRight)) 
        {
            PlayerStates.instance.SetEvent(PlayerStates.Events.Stop);
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
