using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour // Despues ver de refactorizar esta clase y la del ataque del jugador
{
    protected EnemyPosition enemyPosition;
    protected EnemyMove enemyMove;
    protected Vector3 attackBoxVector;
    public int attackDamage;
    public float attackHorizontalDifference;
    public float attackVerticalDifference;
    protected float attackTime;
    protected int directionModifier;

    protected void Begin() 
    {
        enemyPosition = GetComponentInParent<EnemyPosition>();
        enemyMove = GetComponentInParent<EnemyMove>();
        attackTime = 0;
        attackBoxVector = enemyPosition.GetEnemyPosition();
        directionModifier = 1;
        this.gameObject.SetActive(false);
    }

    /*private void Start()
    {
        Begin();
    }*/

    void CheckDirection() 
    {
        if (!enemyMove.GetDirection()) 
        {
            directionModifier *= -1;
            return;
        }
        directionModifier = 1;
    }

    protected virtual void Attack() 
    {
        /*attackBoxVector.x = enemyPosition.GetEnemyPosition().x + attackHorizontalDifference * directionModifier;
        attackBoxVector.y = enemyPosition.GetEnemyPosition().y + attackVerticalDifference;
        this.gameObject.transform.position = attackBoxVector;*/
    }

    public int GetAttackDamage() 
    {
        return attackDamage;
    }

    protected void Behave() 
    {
        CheckDirection();
        Attack();
    }

    /*private void Update()
    {
        Behave();
    }*/
}
