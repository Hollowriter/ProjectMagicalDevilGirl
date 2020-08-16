using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombo : BasicStates
{
    public enum ComboStates 
    {
        None,
        Air,
        FirstPunch,
        WaitSecondPunch,
        SecondPunch,
        WaitThirdPunch,
        ThirdPunch
    }

    public enum ComboEvents 
    {
        LandPunch,
        WaitCombo,
        OnAir,
        Grounded,
        StopCombo
    }

    void StartMachine() 
    {
        stateMachine = new StateMachine();
        stateMachine.Init(7, 5);
    }

    void FirstComboRelations() 
    {
        stateMachine.SetRelation((int)ComboStates.None, (int)ComboEvents.LandPunch, (int)ComboStates.FirstPunch);
        stateMachine.SetRelation((int)ComboStates.WaitSecondPunch, (int)ComboEvents.LandPunch, (int)ComboStates.SecondPunch);
        stateMachine.SetRelation((int)ComboStates.WaitThirdPunch, (int)ComboEvents.LandPunch, (int)ComboStates.ThirdPunch);
    }

    void WaitCombo() 
    {
        stateMachine.SetRelation((int)ComboStates.FirstPunch, (int)ComboEvents.WaitCombo, (int)ComboStates.WaitSecondPunch);
        stateMachine.SetRelation((int)ComboStates.SecondPunch, (int)ComboEvents.WaitCombo, (int)ComboStates.WaitThirdPunch);
    }

    void CancelCombo() 
    {
        stateMachine.SetRelation((int)ComboStates.FirstPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
        stateMachine.SetRelation((int)ComboStates.SecondPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
        stateMachine.SetRelation((int)ComboStates.ThirdPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
        stateMachine.SetRelation((int)ComboStates.WaitSecondPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
        stateMachine.SetRelation((int)ComboStates.WaitThirdPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
    }

    void AirRelations() 
    {
        stateMachine.SetRelation((int)ComboStates.None, (int)ComboEvents.OnAir, (int)ComboStates.Air);
        stateMachine.SetRelation((int)ComboStates.Air, (int)ComboEvents.Grounded, (int)ComboStates.None);
    }

    void EndCombo() 
    {
        stateMachine.SetRelation((int)ComboStates.ThirdPunch, (int)ComboEvents.LandPunch, (int)ComboStates.None);
    }

    protected override void RelationsBegin() 
    {
        FirstComboRelations();
        WaitCombo();
        CancelCombo();
        AirRelations();
        EndCombo();
    }

    private void Awake()
    {
        StartMachine();
        RelationsBegin();
    }
}
