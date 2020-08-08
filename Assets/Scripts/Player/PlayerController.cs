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
            PlayerWalk.instance.WalkLeft();
        }
    }

    void PressedRight() 
    {
        if (Input.GetKey(InputManager.instance.walkRight)) 
        {
            PlayerWalk.instance.WalkRight();
        }
    }

    void PressedJump() 
    {
        if (Input.GetKey(InputManager.instance.jump)) 
        {
            PlayerJump.instance.Jump();
        }
    }

    void CheckControls() 
    {
        if (InputManager.instance.inputDetected()) 
        {
            PressedLeft();
            PressedRight();
            PressedJump();
        }
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
