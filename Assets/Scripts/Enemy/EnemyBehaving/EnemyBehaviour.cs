using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBehaviour : MonoBehaviour
{
    EnemyStates enemyStates;
    EnemyPosition enemyPosition;
    EnemyMove enemyMove;
    EnemyJump enemyJump;
    float behaviourTimer;
    public float deactivateAttackTime;
    public float deactivateRetreatTime;
    public float deactivateFlinchingTime;
    public float standUpTime;

    void Begin() 
    {
        enemyStates = GetComponent<EnemyStates>();
        enemyPosition = GetComponent<EnemyPosition>();
        enemyMove = GetComponent<EnemyMove>();
        enemyJump = GetComponent<EnemyJump>();
        behaviourTimer = 0;
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

    void AttackPlayer() 
    {
        if (enemyPosition.ShouldBeAttacking()) 
        {
            enemyStates.SetEvent((int)EnemyStates.BaddieEvents.Attack);
        }
        else 
        {
            enemyStates.SetEvent((int)EnemyStates.BaddieEvents.StopAttack);
        }
    }

    void TimeAttack() 
    {
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.AttackingPlayer) 
        {
            behaviourTimer += Time.deltaTime;
            if (behaviourTimer >= deactivateAttackTime)
            {
                enemyStates.SetEvent((int)EnemyStates.BaddieEvents.Retreat);
                behaviourTimer = 0;
            }
        }
    }

    void Retreat() 
    {
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.Retreating) 
        {
            behaviourTimer += Time.deltaTime;
            enemyMove.UpdateRetreat();
            if (behaviourTimer >= deactivateRetreatTime)
            {
                enemyStates.SetEvent((int)EnemyStates.BaddieEvents.StopRetreat);
                behaviourTimer = 0;
            }
        }
    }

    void FlinchDamage() 
    {
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.Damaged) 
        {
            behaviourTimer += Time.deltaTime;
            if (behaviourTimer >= deactivateFlinchingTime) 
            {
                enemyStates.SetEvent((int)EnemyStates.BaddieEvents.Recover);
                behaviourTimer = 0;
            }
        }
    }

    void StandingUp() 
    {
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.Down) 
        {
            behaviourTimer += Time.deltaTime;
            if (behaviourTimer >= standUpTime) 
            {
                enemyStates.SetEvent((int)EnemyStates.BaddieEvents.Recover);
                behaviourTimer = 0;
            }
        }
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.Standing) 
        {
            enemyStates.SetEvent((int)EnemyStates.BaddieEvents.Stand);
        }
    }

    void GravityEnemy()
    {
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.FallingFromFloor 
            || enemyStates.GetState() == (int)EnemyStates.BaddieStates.FallingWhileIdle
            || enemyStates.GetState() == (int)EnemyStates.BaddieStates.Jumping)
        {
            enemyJump.UpdateGravity(enemyStates);
        }
    }

    void Behave() 
    {
        DetectPlayer();
        MoveEnemy();
        AttackPlayer();
        TimeAttack();
        Retreat();
        FlinchDamage();
        StandingUp();
        GravityEnemy();
    }

    private void Update()
    {
        Behave();
    }
}
