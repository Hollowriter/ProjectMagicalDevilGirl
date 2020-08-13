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
        if (PlayerCombo.instance.GetState() == (int)PlayerCombo.ComboStates.None) 
        {
            timer = 0;
            return;
        }
        if (PlayerCombo.instance.GetState() == (int)PlayerCombo.ComboStates.WaitSecondPunch ||
            PlayerCombo.instance.GetState() == (int)PlayerCombo.ComboStates.WaitThirdPunch) 
        {
            timer += Time.deltaTime;
            if (timer >= maxComboTime) 
            {
                PlayerCombo.instance.SetEvent(PlayerCombo.ComboEvents.StopCombo);
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
