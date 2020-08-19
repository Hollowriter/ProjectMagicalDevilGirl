﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    EnemyStates enemyStates;
    EnemyPosition enemyPosition;
    EnemyMove enemyMove;
    EnemyJump enemyJump;

    void Begin() 
    {
        enemyStates = GetComponent<EnemyStates>();
        enemyPosition = GetComponent<EnemyPosition>();
        enemyMove = GetComponent<EnemyMove>();
        enemyJump = GetComponent<EnemyJump>();
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

    void GravityEnemy()
    {
    	enemyJump.UpdateGravity();
    }

    void Behave() 
    {
        DetectPlayer();
        MoveEnemy();
        GravityEnemy();
    }

    private void Update()
    {
        Behave();
    }
}
