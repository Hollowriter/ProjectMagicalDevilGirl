using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRetreat : MonoBehaviour
{
    EnemyStates enemyStates;
    EnemyMove enemyMove;
    float behaviourTimer;
    public float deactivateRetreatTime;
    
    void Begin() 
    {
        enemyStates = GetComponent<EnemyStates>();
        enemyMove = GetComponent<EnemyMove>();
        behaviourTimer = 0;
    }

    private void Start()
    {
        Begin();
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

    public void BehaveRetreat() 
    {
        Retreat();
    }
}
