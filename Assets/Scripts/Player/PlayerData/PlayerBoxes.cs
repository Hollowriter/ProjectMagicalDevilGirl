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
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.Punching) 
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
