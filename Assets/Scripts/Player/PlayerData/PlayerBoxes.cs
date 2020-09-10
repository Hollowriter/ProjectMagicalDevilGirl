using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxes : SingletonBase<PlayerBoxes>
{
    [SerializeField]
    GameObject attackBox;

    private void Awake()
    {
        SingletonAwake();
    }

    void AttackBox() 
    {
        if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.Punching ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.HeavyPunching ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickIdle ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickLeft ||
            PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickRight) 
        {
            attackBox.SetActive(true);
        }
    }

    public bool AttackBoxIsActive() 
    {
        return attackBox.activeInHierarchy;
    }

    protected override void BehaveSingleton()
    {
        AttackBox();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
