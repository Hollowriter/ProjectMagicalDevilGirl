using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisions : SingletonBase<AttackCollisions>
{
    private void Awake()
    {
        SingletonAwake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.Punching || 
                PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.HeavyPunching) 
            {
                PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.LandPunch);
                if (PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.Punching)
                {
                    PlayerMachines.instance.GetComboMachine().SetEvent((int)PlayerCombo.ComboEvents.LandPunch);
                }
                else 
                {
                    PlayerMachines.instance.GetComboMachine().SetEvent((int)PlayerCombo.ComboEvents.HeavyLand);
                }
            }
        }
    }
}
