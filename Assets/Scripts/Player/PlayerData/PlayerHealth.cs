using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : SingletonBase<PlayerHealth>
{
    public int maxHealth;
    int health;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        health = maxHealth;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetHealth(int _health) 
    {
        health = _health;
    }

    public int GetHealth() 
    {
        return health;
    }

    void CheckIfDead() 
    {
        if (health <= 0) 
        {
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.KnockedOut); // PENDIENTE DE QUE SE MUERA EL PERSONAJE
        }
    }

    protected override void BehaveSingleton()
    {
        base.BehaveSingleton();
        CheckIfDead();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
