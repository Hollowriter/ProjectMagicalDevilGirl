using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoxes : MonoBehaviour
{
    [SerializeField]
    GameObject attackBox;
    public float attackBoxSpeed;
    public float attackBoxTime;
    float attackBoxTimer;
    EnemyStates enemyStates;

    void Begin() 
    {
        attackBoxTimer = 0;
        enemyStates = GetComponent<EnemyStates>();
    }

    private void Awake()
    {
        Begin();
    }

    void AttackBox() 
    {
        if (enemyStates.GetState() == (int)EnemyStates.BaddieStates.AttackingPlayer) // Nota: Crear un behaviour aparte para las piedras
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

    void CheckAttackBoxTimer() 
    {
        if (attackBox.GetComponent<EnemyThrow>() != null) 
        {
            attackBox.GetComponent<EnemyThrow>().SetAttackTimer(attackBoxTimer);
        }
    }

    void Behave() 
    {
        AttackBox();
        CheckAttackBoxTimer();
    }

    private void Update()
    {
        Behave();
    }
}
