using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombo : SingletonBase<PlayerCombo>
{
    StateMachine comboMachine;

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
        comboMachine = new StateMachine();
        comboMachine.Init(7, 5);
    }

    void FirstComboRelations() 
    {
        comboMachine.SetRelation((int)ComboStates.None, (int)ComboEvents.LandPunch, (int)ComboStates.FirstPunch);
        comboMachine.SetRelation((int)ComboStates.WaitSecondPunch, (int)ComboEvents.LandPunch, (int)ComboStates.SecondPunch);
        comboMachine.SetRelation((int)ComboStates.WaitThirdPunch, (int)ComboEvents.LandPunch, (int)ComboStates.ThirdPunch);
    }

    void WaitCombo() 
    {
        comboMachine.SetRelation((int)ComboStates.FirstPunch, (int)ComboEvents.WaitCombo, (int)ComboStates.WaitSecondPunch);
        comboMachine.SetRelation((int)ComboStates.SecondPunch, (int)ComboEvents.WaitCombo, (int)ComboStates.WaitThirdPunch);
    }

    void CancelCombo() 
    {
        comboMachine.SetRelation((int)ComboStates.FirstPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
        comboMachine.SetRelation((int)ComboStates.SecondPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
        comboMachine.SetRelation((int)ComboStates.ThirdPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
        comboMachine.SetRelation((int)ComboStates.WaitSecondPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
        comboMachine.SetRelation((int)ComboStates.WaitThirdPunch, (int)ComboEvents.StopCombo, (int)ComboStates.None);
    }

    void AirRelations() 
    {
        comboMachine.SetRelation((int)ComboStates.None, (int)ComboEvents.OnAir, (int)ComboStates.Air);
        comboMachine.SetRelation((int)ComboStates.Air, (int)ComboEvents.Grounded, (int)ComboStates.None);
    }

    void EndCombo() 
    {
        comboMachine.SetRelation((int)ComboStates.ThirdPunch, (int)ComboEvents.LandPunch, (int)ComboStates.None);
    }

    void RelationsBegin() 
    {
        FirstComboRelations();
        WaitCombo();
        CancelCombo();
        AirRelations();
        EndCombo();
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

    public void SetEvent(ComboEvents theEvent)
    {
        comboMachine.SetEvent((int)theEvent);
    }

    public int GetState()
    {
        return comboMachine.GetState();
    }
}
