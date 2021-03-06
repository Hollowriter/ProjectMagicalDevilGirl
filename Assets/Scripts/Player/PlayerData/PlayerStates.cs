﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : BasicStates
{
    public enum States 
    {
        Idle,
        WalkingLeft,
        WalkingRight,
        JumpIdle,
        JumpRight,
        JumpLeft,
        FallIdle,
        FallRight,
        FallLeft,
        AirKickIdle,
        AirKickRight,
        AirKickLeft,
        Punching,
        HeavyPunching,
        ConnectedPunching,
        ConnectedHeavyPunching,
        Damaged,
        FallDamaged,
        Recovering,
        OnFloor,
        FallKnocked,
        TKO
    }

    public enum Events 
    {
        WalkLeft,
        WalkRight,
        Stop,
        Jump,
        FallJump,
        FallUngrounded,
        Landed,
        Punch,
        HeavyPunch,
        LandPunch,
        StopPunch,
        Hit,
        Recover,
        Stand,
        KnockedOut
    }

    void WalkRelations() 
    {
        stateMachine.SetRelation((int)States.Idle, (int)Events.WalkLeft, (int)States.WalkingLeft);
        stateMachine.SetRelation((int)States.Idle, (int)Events.WalkRight, (int)States.WalkingRight);
        stateMachine.SetRelation((int)States.WalkingLeft, (int)Events.Stop, (int)States.Idle);
        stateMachine.SetRelation((int)States.WalkingRight, (int)Events.Stop, (int)States.Idle);
    }

    void JumpRelations() 
    {
        stateMachine.SetRelation((int)States.Idle, (int)Events.Jump, (int)States.JumpIdle);
        stateMachine.SetRelation((int)States.WalkingLeft, (int)Events.Jump, (int)States.JumpLeft);
        stateMachine.SetRelation((int)States.WalkingRight, (int)Events.Jump, (int)States.JumpRight);
    }

    void FallRelations() 
    {
        stateMachine.SetRelation((int)States.JumpIdle, (int)Events.FallJump, (int)States.FallIdle);
        stateMachine.SetRelation((int)States.JumpLeft, (int)Events.FallJump, (int)States.FallLeft);
        stateMachine.SetRelation((int)States.JumpRight, (int)Events.FallJump, (int)States.FallRight);
        stateMachine.SetRelation((int)States.Idle, (int)Events.FallUngrounded, (int)States.FallIdle);
        stateMachine.SetRelation((int)States.WalkingLeft, (int)Events.FallUngrounded, (int)States.FallLeft);
        stateMachine.SetRelation((int)States.WalkingRight, (int)Events.FallUngrounded, (int)States.FallRight);
        stateMachine.SetRelation((int)States.FallIdle, (int)Events.Landed, (int)States.Idle);
        stateMachine.SetRelation((int)States.FallLeft, (int)Events.Landed, (int)States.Idle);
        stateMachine.SetRelation((int)States.FallRight, (int)Events.Landed, (int)States.Idle);
        stateMachine.SetRelation((int)States.AirKickIdle, (int)Events.Landed, (int)States.Idle);
        stateMachine.SetRelation((int)States.AirKickLeft, (int)Events.Landed, (int)States.Idle);
        stateMachine.SetRelation((int)States.AirKickRight, (int)Events.Landed, (int)States.Idle);
        stateMachine.SetRelation((int)States.FallDamaged, (int)Events.Landed, (int)States.OnFloor);
        stateMachine.SetRelation((int)States.FallKnocked, (int)Events.Landed, (int)States.TKO);
    }

    void AttackRelations() 
    {
        stateMachine.SetRelation((int)States.Idle, (int)Events.Punch, (int)States.Punching);
        stateMachine.SetRelation((int)States.WalkingLeft, (int)Events.Punch, (int)States.Punching);
        stateMachine.SetRelation((int)States.WalkingRight, (int)Events.Punch, (int)States.Punching);
        stateMachine.SetRelation((int)States.Punching, (int)Events.LandPunch, (int)States.ConnectedPunching);
        stateMachine.SetRelation((int)States.ConnectedPunching, (int)Events.Punch, (int)States.Punching);
        stateMachine.SetRelation((int)States.JumpIdle, (int)Events.Punch, (int)States.AirKickIdle);
        stateMachine.SetRelation((int)States.JumpLeft, (int)Events.Punch, (int)States.AirKickLeft);
        stateMachine.SetRelation((int)States.JumpRight, (int)Events.Punch, (int)States.AirKickRight);
        stateMachine.SetRelation((int)States.FallIdle, (int)Events.Punch, (int)States.AirKickIdle);
        stateMachine.SetRelation((int)States.FallLeft, (int)Events.Punch, (int)States.AirKickLeft);
        stateMachine.SetRelation((int)States.FallRight, (int)Events.Punch, (int)States.AirKickRight);
        stateMachine.SetRelation((int)States.Punching, (int)Events.StopPunch, (int)States.Idle);
        stateMachine.SetRelation((int)States.ConnectedPunching, (int)Events.StopPunch, (int)States.Idle);
    }

    void HeavyAttackRelations() 
    {
        stateMachine.SetRelation((int)States.Idle, (int)Events.HeavyPunch, (int)States.HeavyPunching);
        stateMachine.SetRelation((int)States.WalkingLeft, (int)Events.HeavyPunch, (int)States.HeavyPunching);
        stateMachine.SetRelation((int)States.WalkingRight, (int)Events.HeavyPunch, (int)States.HeavyPunching);
        stateMachine.SetRelation((int)States.HeavyPunching, (int)Events.LandPunch, (int)States.ConnectedHeavyPunching);
        stateMachine.SetRelation((int)States.HeavyPunching, (int)Events.StopPunch, (int)States.Idle);
        stateMachine.SetRelation((int)States.ConnectedHeavyPunching, (int)Events.StopPunch, (int)States.Idle);
    }

    void DamageRelations() 
    {
        stateMachine.SetRelation((int)States.Idle, (int)Events.Hit, (int)States.Damaged);
        stateMachine.SetRelation((int)States.WalkingLeft, (int)Events.Hit, (int)States.Damaged);
        stateMachine.SetRelation((int)States.WalkingRight, (int)Events.Hit, (int)States.Damaged);
        stateMachine.SetRelation((int)States.Punching, (int)Events.Hit, (int)States.Damaged);
        stateMachine.SetRelation((int)States.ConnectedPunching, (int)Events.Hit, (int)States.Damaged);
        stateMachine.SetRelation((int)States.HeavyPunching, (int)Events.Hit, (int)States.Damaged);
        stateMachine.SetRelation((int)States.ConnectedHeavyPunching, (int)Events.Hit, (int)States.Damaged);
        stateMachine.SetRelation((int)States.JumpIdle, (int)Events.Hit, (int)States.FallDamaged);
        stateMachine.SetRelation((int)States.JumpLeft, (int)Events.Hit, (int)States.FallDamaged);
        stateMachine.SetRelation((int)States.JumpRight, (int)Events.Hit, (int)States.FallDamaged);
        stateMachine.SetRelation((int)States.FallIdle, (int)Events.Hit, (int)States.FallDamaged);
        stateMachine.SetRelation((int)States.FallLeft, (int)Events.Hit, (int)States.FallDamaged);
        stateMachine.SetRelation((int)States.FallRight, (int)Events.Hit, (int)States.FallDamaged);
    }

    void RecoveringRelations() 
    {
        stateMachine.SetRelation((int)States.Damaged, (int)Events.Recover, (int)States.Idle);
        stateMachine.SetRelation((int)States.OnFloor, (int)Events.Recover, (int)States.Recovering);
        stateMachine.SetRelation((int)States.Recovering, (int)Events.Stand, (int)States.Idle);
    }

    void KORelations() 
    {
        stateMachine.SetRelation((int)States.Idle, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.WalkingLeft, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.WalkingRight, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.Punching, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.ConnectedPunching, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.HeavyPunching, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.ConnectedHeavyPunching, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.JumpIdle, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.JumpLeft, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.JumpRight, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.FallIdle, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.FallLeft, (int)Events.KnockedOut, (int)States.FallKnocked);
        stateMachine.SetRelation((int)States.FallRight, (int)Events.KnockedOut, (int)States.FallKnocked);
    }

    protected override void RelationsBegin() 
    {
        WalkRelations();
        JumpRelations();
        FallRelations();
        AttackRelations();
        HeavyAttackRelations();
        DamageRelations();
        RecoveringRelations();
        KORelations();
    }

    protected override void Begin()
    {
        StartMachine(22, 15);
        RelationsBegin();
        SetEvent((int)Events.FallUngrounded);
    }

    private void Awake()
    {
        Begin();
    }
}
