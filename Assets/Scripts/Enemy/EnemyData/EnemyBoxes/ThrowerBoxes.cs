using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerBoxes : EnemyBoxes
{
    private void Awake()
    {
        Begin();
    }

    protected override void AttackBox()
    {
        if (!attackBox.activeInHierarchy && enemyStates.GetState() == (int)EnemyStates.BaddieStates.AttackingPlayer) 
        {
            attackBox.SetActive(true);
            attackBoxTimer = 0;
        }
        if (attackBox.activeInHierarchy) 
        {
            attackBoxTimer += attackBoxSpeed * Time.deltaTime;
            if (attackBoxTimer >= attackBoxTime) 
            {
                attackBoxTimer = 0;
                attackBox.SetActive(false);
            }
        }
    }

    private void Update()
    {
        Behave();
    }
}
