﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : BasicStates
{
    public enum BaddieStates 
    {
        Idle,
        GoingToPlayer,
        AttackingPlayer,
        Retreating,
        Jumping,
        FallingFromFloor,
        FallingWhileIdle,
        Damaged,
        Falling,
        FallingKnocked,
        Down,
        Standing,
        TKO
    }

    public enum BaddieEvents 
    {
        PlayerDetected,
        Attack,
        StopAttack,
        Jump,
        StopJump,
        Retreat,
        StopRetreat,
        NoFloor,
        Hit,
        Recover,
        Fall,
        Grounded,
        Stand,
        KnockedOut
    }

    void BaseRelations() 
    {
        stateMachine.SetRelation((int)BaddieStates.Idle, (int)BaddieEvents.PlayerDetected, (int)BaddieStates.GoingToPlayer);
        stateMachine.SetRelation((int)BaddieStates.GoingToPlayer, (int)BaddieEvents.Attack, (int)BaddieStates.AttackingPlayer);
        stateMachine.SetRelation((int)BaddieStates.AttackingPlayer, (int)BaddieEvents.StopAttack, (int)BaddieStates.GoingToPlayer);
        stateMachine.SetRelation((int)BaddieStates.GoingToPlayer, (int)BaddieEvents.Jump, (int)BaddieStates.Jumping);
        stateMachine.SetRelation((int)BaddieStates.AttackingPlayer, (int)BaddieEvents.Retreat, (int)BaddieStates.Retreating);
        stateMachine.SetRelation((int)BaddieStates.Retreating, (int)BaddieEvents.StopRetreat, (int)BaddieStates.GoingToPlayer);
    }

    void GravityRelations() 
    {
        stateMachine.SetRelation((int)BaddieStates.Idle, (int)BaddieEvents.NoFloor, (int)BaddieStates.FallingWhileIdle);
        stateMachine.SetRelation((int)BaddieStates.GoingToPlayer, (int)BaddieEvents.NoFloor, (int)BaddieStates.FallingFromFloor);
        stateMachine.SetRelation((int)BaddieStates.Retreating, (int)BaddieEvents.NoFloor, (int)BaddieStates.FallingFromFloor);
        stateMachine.SetRelation((int)BaddieStates.Jumping, (int)BaddieEvents.StopJump, (int)BaddieStates.FallingFromFloor);
        stateMachine.SetRelation((int)BaddieStates.FallingWhileIdle, (int)BaddieEvents.Grounded, (int)BaddieStates.Idle);
        stateMachine.SetRelation((int)BaddieStates.FallingFromFloor, (int)BaddieEvents.Grounded, (int)BaddieStates.GoingToPlayer);
        stateMachine.SetRelation((int)BaddieStates.Falling, (int)BaddieEvents.Grounded, (int)BaddieStates.Down);
        stateMachine.SetRelation((int)BaddieStates.FallingKnocked, (int)BaddieEvents.Grounded, (int)BaddieStates.TKO);
    }
    
    void GettingHitRelations() 
    {
        stateMachine.SetRelation((int)BaddieStates.Idle, (int)BaddieEvents.Hit, (int)BaddieStates.Damaged);
        stateMachine.SetRelation((int)BaddieStates.GoingToPlayer, (int)BaddieEvents.Hit, (int)BaddieStates.Damaged);
        stateMachine.SetRelation((int)BaddieStates.AttackingPlayer, (int)BaddieEvents.Hit, (int)BaddieStates.Damaged);
        stateMachine.SetRelation((int)BaddieStates.Retreating, (int)BaddieEvents.Hit, (int)BaddieStates.Damaged);
        stateMachine.SetRelation((int)BaddieStates.Jumping, (int)BaddieEvents.Hit, (int)BaddieStates.Falling);
        stateMachine.SetRelation((int)BaddieStates.FallingFromFloor, (int)BaddieEvents.Hit, (int)BaddieStates.Falling);
    }

    void GettingStrongHitRelations() 
    {
        stateMachine.SetRelation((int)BaddieStates.Idle, (int)BaddieEvents.Fall, (int)BaddieStates.Falling);
        stateMachine.SetRelation((int)BaddieStates.GoingToPlayer, (int)BaddieEvents.Fall, (int)BaddieStates.Falling);
        stateMachine.SetRelation((int)BaddieStates.AttackingPlayer, (int)BaddieEvents.Fall, (int)BaddieStates.Falling);
        stateMachine.SetRelation((int)BaddieStates.Retreating, (int)BaddieEvents.Fall, (int)BaddieStates.Falling);
        stateMachine.SetRelation((int)BaddieStates.Jumping, (int)BaddieEvents.Fall, (int)BaddieStates.Falling);
        stateMachine.SetRelation((int)BaddieStates.FallingFromFloor, (int)BaddieEvents.Fall, (int)BaddieStates.Falling);
    }

    void GettingKnockedRelations() 
    {
        stateMachine.SetRelation((int)BaddieStates.Idle, (int)BaddieEvents.KnockedOut, (int)BaddieStates.TKO);
        stateMachine.SetRelation((int)BaddieStates.GoingToPlayer, (int)BaddieEvents.KnockedOut, (int)BaddieStates.TKO);
        stateMachine.SetRelation((int)BaddieStates.AttackingPlayer, (int)BaddieEvents.KnockedOut, (int)BaddieStates.TKO);
        stateMachine.SetRelation((int)BaddieStates.Retreating, (int)BaddieEvents.KnockedOut, (int)BaddieStates.TKO);
        stateMachine.SetRelation((int)BaddieStates.FallingFromFloor, (int)BaddieEvents.KnockedOut, (int)BaddieStates.FallingKnocked);
        stateMachine.SetRelation((int)BaddieStates.Falling, (int)BaddieEvents.KnockedOut, (int)BaddieStates.FallingKnocked);
    }

    void RecoveringRelations() 
    {
        stateMachine.SetRelation((int)BaddieStates.Damaged, (int)BaddieEvents.Recover, (int)BaddieStates.GoingToPlayer);
        stateMachine.SetRelation((int)BaddieStates.Down, (int)BaddieEvents.Recover, (int)BaddieStates.Standing);
        stateMachine.SetRelation((int)BaddieStates.Standing, (int)BaddieEvents.Stand, (int)BaddieStates.GoingToPlayer);
    }

    protected override void RelationsBegin()
    {
        BaseRelations();
        GravityRelations();
        GettingHitRelations();
        GettingStrongHitRelations();
        GettingKnockedRelations();
        RecoveringRelations();
    }

    protected override void Begin()
    {
        StartMachine(13, 14);
        RelationsBegin();
        SetEvent((int)BaddieEvents.NoFloor);
    }

    private void Awake()
    {
        Begin();
    }
}
