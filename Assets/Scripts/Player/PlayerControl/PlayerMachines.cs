using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMachines : SingletonBase<PlayerMachines>
{
    PlayerStates stateMachine;
    PlayerCombo comboMachine;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        stateMachine = GetComponent<PlayerStates>();
        comboMachine = GetComponent<PlayerCombo>();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public PlayerStates GetPlayerStateMachine() 
    {
        return stateMachine;
    }

    public PlayerCombo GetComboMachine() 
    {
        return comboMachine;
    }
}
