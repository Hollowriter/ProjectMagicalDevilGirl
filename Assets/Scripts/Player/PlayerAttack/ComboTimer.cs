using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTimer : SingletonBase<ComboTimer>
{
    float timer;
    public float maxComboTime;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        timer = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void TimeIsTicking() 
    {
        if (PlayerMachines.instance.GetComboMachine().GetState() == (int)PlayerCombo.ComboStates.None) 
        {
            timer = 0;
            return;
        }
        if (PlayerMachines.instance.GetComboMachine().GetState() == (int)PlayerCombo.ComboStates.WaitSecondPunch ||
            PlayerMachines.instance.GetComboMachine().GetState() == (int)PlayerCombo.ComboStates.WaitThirdPunch ||
            PlayerMachines.instance.GetComboMachine().GetState() == (int)PlayerCombo.ComboStates.HeavyPunch) 
        {
            timer += Time.deltaTime;
            if (timer >= maxComboTime) 
            {
                PlayerMachines.instance.GetComboMachine().SetEvent((int)PlayerCombo.ComboEvents.StopCombo);
            }
        }
    }

    protected override void BehaveSingleton()
    {
        TimeIsTicking();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
