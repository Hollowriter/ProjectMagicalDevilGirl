using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrow : EnemyAttack // NOTA: Agregarle un script the colisiones a este tipo de ataque
{
    float attackTimer;

    protected override void BeginAttack()
    {
        base.BeginAttack();
        attackTimer = 0;
    }

    private void Start()
    {
        BeginAttack();
    }

    protected override void Attack()
    {
        attackBoxVector.x = enemyPosition.GetEnemyPosition().x + attackTimer * directionModifier;
        attackBoxVector.y = enemyPosition.GetEnemyPosition().y + attackVerticalDifference;
        this.gameObject.transform.position = attackBoxVector;
    }

    /*void TimeControl() 
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackTime) 
        {
            attackTimer = 0;
            this.gameObject.SetActive(false);
        }
    }*/

    public void SetAttackTimer(float _attackTimer) 
    {
        attackTimer = _attackTimer;
    }

    public float GetAttackTimer() 
    {
        return attackTimer;
    }

    protected override void BehaveAttack()
    {
        base.BehaveAttack();
        // TimeControl();
    }

    private void Update()
    {
        BehaveAttack();
    }
}
