using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    EnemyStates enemyStates;
    EnemyHealth enemyHealth;
    float behaviourTimer;
    public float dissappearTime;

    void Begin() 
    {
        enemyStates = GetComponent<EnemyStates>();
        enemyHealth = GetComponent<EnemyHealth>();
        behaviourTimer = 0;
    }

    private void Start()
    {
        Begin();
    }

    void CheckIfDead()
    {
        if (enemyHealth.GetHealth() <= 0)
        {
            enemyStates.SetEvent((int)EnemyStates.BaddieEvents.KnockedOut);
        }
    }

    void MakeEnemyDissappear()
    {
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.TKO)
        {
            behaviourTimer += Time.deltaTime;
            if (behaviourTimer >= dissappearTime)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void DeathCheck() 
    {
        CheckIfDead();
        MakeEnemyDissappear();
    }
}
