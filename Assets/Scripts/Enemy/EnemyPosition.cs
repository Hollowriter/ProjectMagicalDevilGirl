using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    Vector3 enemyPosition;

    void Begin() 
    {
        enemyPosition = GetComponent<Transform>().position;
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

    void UpdatePosition()
    {
        enemyPosition = this.gameObject.GetComponent<Transform>().position;
    }

    private void Update()
    {
        UpdatePosition();
    }
}
