using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseController : SingletonBase<PhaseController>
{
    public List<GameObject> groupsOfEnemies;
    public int deconstrainPhase;
    int currentPhase;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        currentPhase = 0;
    }

    private void Start()
    {
        SingletonAwake();
    }

    void CheckPhase() 
    {
        if (currentPhase < groupsOfEnemies.Count)
        {
            if (groupsOfEnemies[currentPhase].GetComponent<EnemyGroup>().CheckAllEnemiesDefeated())
            {
                currentPhase++;
                RealTimeConstrainer.instance.Deconstrain(deconstrainPhase);
            }
        }
    }

    protected override void BehaveSingleton()
    {
        CheckPhase();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
