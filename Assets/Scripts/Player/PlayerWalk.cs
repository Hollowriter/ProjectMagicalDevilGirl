using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : SingletonBase<PlayerWalk>
{
    [SerializeField]
    int characterSpeed;
    Vector3 newPlayerPosition;
    bool direction;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        newPlayerPosition = PlayerPosition.instance.GetPlayerPosition();
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

    void PressingRight()
    {
        // playerPosition.x += characterSpeed * Time.deltaTime;
        newPlayerPosition.x += characterSpeed * Time.deltaTime;
        SetDirection(true);
    }

    void PressingLeft()
    {
        newPlayerPosition.x -= characterSpeed * Time.deltaTime;
        SetDirection(false);
    }

    void ApplyMovement() 
    {
        PlayerPosition.instance.SetPlayerPosition(newPlayerPosition);
    }

    void Movement()
    {
        if (InputManager.instance.inputDetected())
        {
            newPlayerPosition = PlayerPosition.instance.GetPlayerPosition();
            if (Input.GetKey(InputManager.instance.walkRight))
            {
                PressingRight();
            }
            if (Input.GetKey(InputManager.instance.walkLeft))
            {
                PressingLeft();
            }
            ApplyMovement();
        }
    }

    protected override void BehaveSingleton()
    {
        Movement();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
