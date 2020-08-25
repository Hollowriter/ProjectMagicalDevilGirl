using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyBehaviour : MonoBehaviour
{
    EnemySeeker enemySeeker;
    EnemyCombo enemyCombo;
    EnemyRetreat enemyRetreat;
    EnemyRecoverer enemyRecoverer;
    EnemyDeath enemyDeath;
    EnemyGravityCheck enemyGravityCheck;

    void Begin() 
    {
        enemySeeker = GetComponent<EnemySeeker>();
        enemyCombo = GetComponent<EnemyCombo>();
        enemyRetreat = GetComponent<EnemyRetreat>();
        enemyRecoverer = GetComponent<EnemyRecoverer>();
        enemyDeath = GetComponent<EnemyDeath>();
        enemyGravityCheck = GetComponent<EnemyGravityCheck>();
    }

    private void Start()
    {
        Begin();
    }

    void Behave() 
    {
        enemySeeker.Seek();
        enemyCombo.BehaveAttack();
        enemyRetreat.BehaveRetreat();
        enemyRecoverer.BehaveRecover();
        enemyDeath.DeathCheck();
        enemyGravityCheck.CheckIfGraivyBehaves();
    }

    private void Update()
    {
        Behave();
    }
}
