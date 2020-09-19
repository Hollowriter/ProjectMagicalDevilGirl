using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    float enemySpeed;
    float newEnemyPositionX;
    bool direction;
    EnemyPosition enemyPosition;

    void Begin() 
    {
        newEnemyPositionX = 0;
        direction = false;
        enemyPosition = GetComponent<EnemyPosition>();
    }

    private void Start()
    {
        Begin();
    }

    public void SetDirection(bool _direction) 
    {
        direction = _direction;
    }

    public bool GetDirection() 
    {
        return direction;
    }

    void MoveRight()
    {
        if (enemyPosition.GetEnemyPositionX() < PlayerPosition.instance.GetPlayerPositionX())
        {
            newEnemyPositionX += enemySpeed * Time.deltaTime;
            SetDirection(true);
        }
    }

    void MoveLeft() 
    {
        if (enemyPosition.GetEnemyPositionX() > PlayerPosition.instance.GetPlayerPositionX()) 
        {
            newEnemyPositionX -= enemySpeed * Time.deltaTime;
            SetDirection(false);
        }
    }

    void RetreatRight()
    {
        if (enemyPosition.GetEnemyPositionX() < PlayerPosition.instance.GetPlayerPositionX() && enemyPosition.GetEnemyPositionX() > AreaConstraints.instance.LeftStageLimit)
        {
            newEnemyPositionX -= enemySpeed * Time.deltaTime;
            SetDirection(true);
        }
    }

    void RetreatLeft()
    {
        if (enemyPosition.GetEnemyPositionX() > PlayerPosition.instance.GetPlayerPositionX() && enemyPosition.GetEnemyPositionX() < AreaConstraints.instance.RightStageLimit)
        {
            newEnemyPositionX += enemySpeed * Time.deltaTime;
            SetDirection(false);
        }
    }

    void ApplyMovement() 
    {
        enemyPosition.SetEnemyPositionX(newEnemyPositionX);
    }

    public void UpdateMovement()
    {
        newEnemyPositionX = enemyPosition.GetEnemyPositionX();
        MoveLeft();
        MoveRight();
        ApplyMovement();
    }

    public void UpdateRetreat() 
    {
        newEnemyPositionX = enemyPosition.GetEnemyPositionX();
        RetreatLeft();
        RetreatRight();
        ApplyMovement();
    }
}
