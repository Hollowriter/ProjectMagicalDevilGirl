using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour // Despues ver de refactorizar esta clase y la del ataque del jugador
{
    EnemyPosition enemyPosition;
    EnemyMove enemyMove;
    Vector3 attackBoxVector;
    public float attackHorizontalDifference;
    public float attackVerticalDifference;
    public float attackDuration; // Esto va a ser reemplazado por animacion tarde o temprano.
    float attackTime;
    int directionModifier;

    void Begin() 
    {
        enemyPosition = GetComponent<EnemyPosition>();
        enemyMove = GetComponent<EnemyMove>();
        attackTime = 0;
        attackBoxVector = enemyPosition.GetEnemyPosition();
        directionModifier = 1;
        this.gameObject.SetActive(false);
    }

    private void Awake()
    {
        Begin();
    }

    void CheckDirection() 
    {
        if (!enemyMove.GetDirection()) 
        {
            directionModifier *= -1;
            return;
        }
        directionModifier = 1;
    }

    void Punch() 
    {
        attackBoxVector.x = enemyPosition.GetEnemyPosition().x + attackHorizontalDifference * directionModifier;
        attackBoxVector.y = enemyPosition.GetEnemyPosition().y + attackVerticalDifference;
        this.gameObject.transform.position = attackBoxVector;
    } // Pendiente de terminar
}
