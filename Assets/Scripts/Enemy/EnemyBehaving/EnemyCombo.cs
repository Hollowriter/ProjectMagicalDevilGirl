using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombo : MonoBehaviour
{
    EnemyStates enemyStates;
    EnemyPosition enemyPosition;
    float behaviourTimer;
    public float deactivateAttackTime;

    void Begin() 
    {
        enemyStates = GetComponent<EnemyStates>();
        enemyPosition = GetComponent<EnemyPosition>();
    }

    private void Start()
    {
        Begin();
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

    public void BehaveAttack() 
    {
        AttackPlayer();
        TimeAttack();
    }
}
