using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunch : EnemyAttack
{
    protected override void BeginAttack()
    {
        base.BeginAttack();
    }

    private void Start()
    {
        BeginAttack();
    }

    protected override void Attack()
    {
        attackBoxVector.x = enemyPosition.GetEnemyPosition().x + attackHorizontalDifference * directionModifier;
        attackBoxVector.y = enemyPosition.GetEnemyPosition().y + attackVerticalDifference;
        this.gameObject.transform.position = attackBoxVector;
    }

    private void Update()
    {
        BehaveAttack();
    }
}
