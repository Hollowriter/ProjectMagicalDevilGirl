using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlerBoxes : EnemyBoxes
{
    private void Awake()
    {
        Begin();
    }

    protected override void AttackBox()
    {
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.AttackingPlayer)
        {
            if (attackBoxTimer >= attackBoxTime)
            {
                if (!attackBox.activeInHierarchy)
                {
                    attackBox.SetActive(true);
                }
                else
                {
                    attackBox.SetActive(false);
                }
                attackBoxTimer = 0;
            }
            attackBoxTimer += attackBoxSpeed * Time.deltaTime;
            return;
        }
        attackBoxTimer = 0;
        attackBox.SetActive(false);
    }

    private void Update()
    {
        Behave();
    }
}
