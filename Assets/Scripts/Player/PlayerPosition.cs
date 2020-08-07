using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : SingletonBase<PlayerPosition>
{
    Vector3 playerPosition;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        playerPosition = this.gameObject.GetComponent<Transform>().position;
    }

    public void SetPlayerPosition(Vector3 _playerPosition) 
    {
        playerPosition = _playerPosition;
        this.gameObject.GetComponent<Transform>().position = playerPosition;
    }

    public Vector3 GetPlayerPosition() 
    {
        return playerPosition;
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
