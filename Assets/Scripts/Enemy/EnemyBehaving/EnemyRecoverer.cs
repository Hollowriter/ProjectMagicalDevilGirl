using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRecoverer : MonoBehaviour
{
    EnemyStates enemyStates;
    float behaviourTimer;
    public float deactivateFlinchingTime;
    public float standUpTime;

    void Begin() 
    {
        enemyStates = GetComponent<EnemyStates>();
        behaviourTimer = 0;
    }

    private void Start()
    {
        Begin();
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

    public void BehaveRecover() 
    {
        FlinchDamage();
        StandingUp();
    }
}
