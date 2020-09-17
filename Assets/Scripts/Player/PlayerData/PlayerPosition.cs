using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerPosition : SingletonBase<PlayerPosition>
{
    Vector3 playerPosition;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        playerPosition = this.gameObject.GetComponent<Transform>().position;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetPlayerPosition(Vector3 _playerPosition) 
    {
        playerPosition = _playerPosition;
        this.gameObject.GetComponent<Transform>().position = playerPosition;
    }

    public void SetPlayerPositionX(float _playerPositionX) 
    {
        playerPosition.x = _playerPositionX;
        playerPosition.y = this.gameObject.GetComponent<Transform>().position.y;
        playerPosition.z = this.gameObject.GetComponent<Transform>().position.z;
        SetPlayerPosition(playerPosition);
    }

    public void SetPlayerPositionY(float _playerPositionY) 
    {
        playerPosition.x = this.gameObject.GetComponent<Transform>().position.x;
        playerPosition.y = _playerPositionY;
        playerPosition.z = this.gameObject.GetComponent<Transform>().position.z;
        SetPlayerPosition(playerPosition);
    }

    public Vector3 GetPlayerPosition() 
    {
        return playerPosition;
    }

    public float GetPlayerPositionX() 
    {
        return playerPosition.x;
    }

    public float GetPlayerPositionY() 
    {
        return playerPosition.y;
    }

    void UpdatePosition() 
    {
        playerPosition = this.gameObject.GetComponent<Transform>().position;
    }

    protected override void BehaveSingleton()
    {
        UpdatePosition();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
