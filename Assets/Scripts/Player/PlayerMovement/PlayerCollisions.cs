using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : SingletonBase<PlayerCollisions>
{
    protected override void SingletonAwake()
    {
        base.SingletonAwake();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.Landed);
            PlayerMachines.instance.GetComboMachine().SetEvent((int)PlayerCombo.ComboEvents.Grounded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.FallUngrounded);
            PlayerMachines.instance.GetComboMachine().SetEvent((int)PlayerCombo.ComboEvents.OnAir);
        }
    }
}
