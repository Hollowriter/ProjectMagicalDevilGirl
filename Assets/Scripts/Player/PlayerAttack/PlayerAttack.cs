using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : SingletonBase<PlayerAttack>
{
    Vector3 attackBoxVector;
    public float attackHorizontalDifference;
    public float attackVerticalDifference;
    public float attackDuration;
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
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.Punching || PlayerStates.instance.GetState() == (int)PlayerStates.States.ConnectedPunching)
        {
            attackBoxVector.x = PlayerPosition.instance.GetPlayerPosition().x + attackHorizontalDifference * directionModifier;
            attackBoxVector.y = PlayerPosition.instance.GetPlayerPosition().y + attackVerticalDifference;
            this.gameObject.transform.position = attackBoxVector;
        }
    }

    void CheckAttackTime() 
    {
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.Punching || PlayerStates.instance.GetState() == (int)PlayerStates.States.ConnectedPunching)
        {
            attackTime += Time.deltaTime;
            if (attackTime >= attackDuration) 
            {
                attackTime = 0;
                PlayerStates.instance.SetEvent(PlayerStates.Events.StopPunch);
                PlayerCombo.instance.SetEvent(PlayerCombo.ComboEvents.WaitCombo);
                this.gameObject.SetActive(false);
            }
        }
    }

    protected override void BehaveSingleton()
    {
        CheckDirection();
        Punch();
        CheckAttackTime();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
