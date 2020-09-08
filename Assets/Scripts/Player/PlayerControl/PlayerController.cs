using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonBase<PlayerController>
{
    bool attackPressed;
    bool heavyAttackPressed;
    bool jumpPressed;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        attackPressed = false;
        heavyAttackPressed = false;
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
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.WalkLeft);
        }
    }

    void PressedRight() 
    {
        if (Input.GetKey(InputManager.instance.walkRight)) 
        {
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.WalkRight);
        }
    }

    void PressedJump() 
    {
        if (Input.GetKey(InputManager.instance.jump) && !jumpPressed) 
        {
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.Jump);
            jumpPressed = true;
        }
    }

    void PressedAttack() 
    {
        if (Input.GetKey(InputManager.instance.attack) && !attackPressed) 
        {
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.Punch);
            attackPressed = true;
        }
    }

    void PressedHeavyAttack() 
    {
        if (Input.GetKey(InputManager.instance.heavyAttack) && !heavyAttackPressed) 
        {
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.HeavyPunch);
            heavyAttackPressed = true;
        }
    }

    void StopPressing() 
    {
        if (Input.GetKeyUp(InputManager.instance.walkLeft) || Input.GetKeyUp(InputManager.instance.walkRight)) 
        {
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.Stop);
        }
        if (Input.GetKeyUp(InputManager.instance.attack)) 
        {
            attackPressed = false;
        }
        if (Input.GetKeyUp(InputManager.instance.heavyAttack)) 
        {
            heavyAttackPressed = false;
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
            PressedHeavyAttack();
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
