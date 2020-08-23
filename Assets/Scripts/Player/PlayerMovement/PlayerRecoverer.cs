using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecoverer : SingletonBase<PlayerRecoverer> // Esto probablemente sea reemplazado cuando lleguen las animaciones
{
    public float recoverTime;
    public float standTime;
    float recoverTimer;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        recoverTimer = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void RecoverFromHit() 
    {
        if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.Damaged) 
        {
            recoverTimer += Time.deltaTime;
            if (recoverTimer >= recoverTime) 
            {
                recoverTimer = 0;
                PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.Recover);
            }
        }
    }

    void StandUp() 
    {
        if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.OnFloor) 
        {
            recoverTimer += Time.deltaTime;
            if (recoverTimer >= standTime) 
            {
                recoverTimer = 0;
                PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.Recover);
            }
        }
        if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.Recovering) 
        {
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.Stand);
        }
    }

    protected override void BehaveSingleton()
    {
        RecoverFromHit();
        StandUp();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
