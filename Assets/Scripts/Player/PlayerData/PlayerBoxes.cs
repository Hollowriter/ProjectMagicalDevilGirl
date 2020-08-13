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
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.Punching ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.AirKickIdle ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.AirKickLeft ||
            PlayerStates.instance.GetState() == (int)PlayerStates.States.AirKickRight) 
        {
            attackBox.SetActive(true);
        }
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
