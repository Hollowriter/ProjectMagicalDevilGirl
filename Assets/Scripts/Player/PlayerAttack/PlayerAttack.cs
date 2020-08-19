using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : SingletonBase<PlayerAttack> // Despues ver de refactorizar esta clase y la del ataque enemigo
{
    Vector3 attackBoxVector;
    public float attackHorizontalDifference;
    public float attackVerticalDifference;
    public float attackDuration; // Esto va a ser reemplazado por animacion tarde o temprano.
    float attackTime;
    int directionModifier;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        attackTime = 0;
        attackBoxVector = PlayerPosition.instance.GetPlayerPosition();
        directionModifier = 1;
        this.gameObject.SetActive(false);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void CheckDirection() 
    {
        if (!PlayerWalk.instance.GetDirection()) 
        {
            directionModifier = -1;
            return;
        }
        directionModifier = 1;
    }

    void Punch() 
    {
        if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.Punching || PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.ConnectedPunching)
        {
            attackBoxVector.x = PlayerPosition.instance.GetPlayerPosition().x + attackHorizontalDifference * directionModifier;
            attackBoxVector.y = PlayerPosition.instance.GetPlayerPosition().y + attackVerticalDifference;
            this.gameObject.transform.position = attackBoxVector;
        }
    }

    void AirKick() 
    {
        if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickIdle 
            || PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickLeft 
            || PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickRight) 
        {
            attackBoxVector.x = PlayerPosition.instance.GetPlayerPosition().x + attackHorizontalDifference * directionModifier;
            attackBoxVector.y = PlayerPosition.instance.GetPlayerPosition().y - attackVerticalDifference;
            this.gameObject.transform.position = attackBoxVector;
        }
    }

    void CheckAttackTime() 
    {
        if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.Punching || PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.ConnectedPunching)
        {
            attackTime += Time.deltaTime;
            if (attackTime >= attackDuration) 
            {
                attackTime = 0;
                PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.StopPunch);
                PlayerMachines.instance.GetComboMachine().SetEvent((int)PlayerCombo.ComboEvents.WaitCombo);
            }
        }
    }

    void CheckAttackActivation() 
    {
        if (!(PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.Punching) && 
            !(PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.ConnectedPunching) &&
            !(PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickIdle) &&
            !(PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickLeft) &&
            !(PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickRight)) 
        {
            this.gameObject.SetActive(false);
        }
    }

    protected override void BehaveSingleton()
    {
        CheckDirection();
        Punch();
        AirKick();
        CheckAttackTime();
        CheckAttackActivation();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
