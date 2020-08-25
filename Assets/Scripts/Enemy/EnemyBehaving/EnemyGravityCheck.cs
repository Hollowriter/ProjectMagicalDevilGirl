using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGravityCheck : MonoBehaviour
{
    EnemyStates enemyStates;
    EnemyJump enemyJump;
    
    void Begin() 
    {
        enemyStates = GetComponent<EnemyStates>();
        enemyJump = GetComponent<EnemyJump>();
    }

    private void Start()
    {
        Begin();
    }

    void GravityEnemy()
    {
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.FallingFromFloor
            || enemyStates.GetState() == (int)EnemyStates.BaddieStates.FallingWhileIdle
            || enemyStates.GetState() == (int)EnemyStates.BaddieStates.Jumping
            || enemyStates.GetState() == (int)EnemyStates.BaddieStates.FallingKnocked)
        {
            enemyJump.UpdateGravity(enemyStates);
        }
    }

    public void CheckIfGraivyBehaves() 
    {
        GravityEnemy();
    }
}
