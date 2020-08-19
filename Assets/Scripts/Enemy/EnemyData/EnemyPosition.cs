using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    Vector3 enemyPosition;
    public float detectPlayerDistance;
    float distanceFromPlayer;

    void Begin() 
    {
        enemyPosition = GetComponent<Transform>().position;
        distanceFromPlayer = 0;
    }

    private void Awake()
    {
        Begin();
    }

    public void SetEnemyPosition(Vector3 _enemyPosition)
    {
        enemyPosition = _enemyPosition;
        this.gameObject.GetComponent<Transform>().position = enemyPosition;
    }

    public void SetEnemyPositionX(float _enemyPositionX)
    {
        enemyPosition.x = _enemyPositionX;
        enemyPosition.y = this.gameObject.GetComponent<Transform>().position.y;
        enemyPosition.z = this.gameObject.GetComponent<Transform>().position.z;
        SetEnemyPosition(enemyPosition);
    }

    public void SetEnemyPositionY(float _enemyPositionY)
    {
        enemyPosition.x = this.gameObject.GetComponent<Transform>().position.x;
        enemyPosition.y = _enemyPositionY;
        enemyPosition.z = this.gameObject.GetComponent<Transform>().position.z;
        SetEnemyPosition(enemyPosition);
    }

    void DistanceEnemyAndPlayer() 
    {
        distanceFromPlayer = enemyPosition.x - PlayerPosition.instance.GetPlayerPositionX();
        if (distanceFromPlayer < 0) 
        {
            distanceFromPlayer *= -1;
        }
    }

    public Vector3 GetEnemyPosition()
    {
        return enemyPosition;
    }

    public float GetEnemyPositionX()
    {
        return enemyPosition.x;
    }

    public float GetEnemyPositionY()
    {
        return enemyPosition.y;
    }

    public bool IsPlayerDetected() 
    {
        if (distanceFromPlayer <= detectPlayerDistance) 
        {
            return true;
        }
        return false;
    }

    void UpdatePosition()
    {
        enemyPosition = this.gameObject.GetComponent<Transform>().position;
    }

    private void Update()
    {
        UpdatePosition();
        DistanceEnemyAndPlayer();
    }
}
