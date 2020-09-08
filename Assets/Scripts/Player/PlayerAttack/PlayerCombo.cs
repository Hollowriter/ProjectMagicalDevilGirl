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
        ThirdPunch,
        HeavyPunch
    }

    public enum ComboEvents 
    {
        LandPunch,
        HeavyLand,
        WaitCombo,
        OnAir,
        Grounded,
        StopCombo
    }

    void FirstComboRelations()
    {
        stateMachine.SetRelation((int)ComboStates.None, (int)ComboEvents.LandPunch, (int)ComboStates.FirstPunch);
        stateMachine.SetRelation((int)ComboStates.WaitSecondPunch, (int)ComboEvents.LandPunch, (int)ComboStates.SecondPunch);
        stateMachine.SetRelation((int)ComboStates.WaitThirdPunch, (int)ComboEvents.LandPunch, (int)ComboStates.ThirdPunch);
    }

    void HeavyComboRelations()
    {
        stateMachine.SetRelation((int)ComboStates.None, (int)ComboEvents.HeavyLand, (int)ComboStates.HeavyPunch);
        stateMachine.SetRelation((int)ComboStates.WaitSecondPunch, (int)ComboEvents.HeavyLand, (int)ComboStates.HeavyPunch);
        stateMachine.SetRelation((int)ComboStates.WaitThirdPunch, (int)ComboEvents.HeavyLand, (int)ComboStates.HeavyPunch);
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
        stateMachine.SetRelation((int)ComboStates.HeavyPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
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
        HeavyComboRelations();
        WaitCombo();
        CancelCombo();
        AirRelations();
        EndCombo();
    }

    protected override void Begin()
    {
        StartMachine(8, 6);
        RelationsBegin();
    }

    private void Awake()
    {
        Begin();
    }
}
