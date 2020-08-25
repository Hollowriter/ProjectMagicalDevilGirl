using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeeker : MonoBehaviour
{
    EnemyStates enemyStates;
    EnemyPosition enemyPosition;
    EnemyMove enemyMove;

    void Begin()
    {
        enemyStates = GetComponent<EnemyStates>();
        enemyPosition = GetComponent<EnemyPosition>();
        enemyMove = GetComponent<EnemyMove>();
    }

    private void Start()
    {
        Begin();
    }

    void DetectPlayer()
    {
        if (enemyPosition.IsPlayerDetected())
        {
            enemyStates.SetEvent((int)EnemyStates.BaddieEvents.PlayerDetected);
        }
    }

    void MoveEnemy()
    {
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.GoingToPlayer)
        {
            enemyMove.UpdateMovement();
        }
    }

    public void Seek() 
    {
        DetectPlayer();
        MoveEnemy();
    }
}
