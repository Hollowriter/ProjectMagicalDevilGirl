using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoxes : MonoBehaviour
{
    [SerializeField]
    protected GameObject attackBox;
    public float attackBoxSpeed;
    public float attackBoxTime;
    protected float attackBoxTimer;
    protected EnemyStates enemyStates;

    protected void Begin() 
    {
        attackBoxTimer = 0;
        enemyStates = GetComponent<EnemyStates>();
    }

    protected virtual void AttackBox() 
    {
    }

    void CheckAttackBoxTimer() 
    {
        if (attackBox.GetComponent<EnemyThrow>() != null) 
        {
            attackBox.GetComponent<EnemyThrow>().SetAttackTimer(attackBoxTimer);
        }
    }

    protected void Behave() 
    {
        AttackBox();
        CheckAttackBoxTimer();
    }
}
