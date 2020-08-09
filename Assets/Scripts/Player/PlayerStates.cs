using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : SingletonBase<PlayerStates>
{
    StateMachine stateMachine;
    int state;

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
        FallLeft
    }

    public enum Events 
    {
        WalkLeft,
        WalkRight,
        Stop,
        Jump,
        FallJump,
        FallUngrounded,
        Landed
    }

    void StartMachine() 
    {
        stateMachine = new StateMachine();
        stateMachine.Init(9, 7);
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
    }

    void RelationsBegin() 
    {
        WalkRelations();
        JumpRelations();
        FallRelations();
    }

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        StartMachine();
        RelationsBegin();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetEvent(Events theEvent) 
    {
        stateMachine.SetEvent((int)theEvent);
    }

    public int GetState() 
    {
        return stateMachine.GetState();
    }
}
