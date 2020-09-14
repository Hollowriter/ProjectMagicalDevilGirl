using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    protected EnemyPosition enemyPosition;
    protected EnemyMove enemyMove;
    protected Vector3 attackBoxVector;
    public int attackDamage;
    public float attackHorizontalDifference;
    public float attackVerticalDifference;
    protected int directionModifier;

    protected virtual void BeginAttack() 
    {
        enemyPosition = GetComponentInParent<EnemyPosition>();
        enemyMove = GetComponentInParent<EnemyMove>();
        attackBoxVector = enemyPosition.GetEnemyPosition();
        directionModifier = 1;
        this.gameObject.SetActive(false);
    }

    void CheckDirection() 
    {
        if (!enemyMove.GetDirection()) 
        {
            directionModifier = -1;
            return;
        }
        directionModifier = 1;
    }

    protected virtual void Attack() 
    {
    }

    public int GetAttackDamage() 
    {
        return attackDamage;
    }

    protected virtual void BehaveAttack() 
    {
        CheckDirection();
        Attack();
    }
}
