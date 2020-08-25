using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : SingletonBase<PlayerCollisions>
{
    private void Awake()
    {
        SingletonAwake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyAttack") 
        {
            if ((PlayerMachines.instance.GetPlayerStateMachine().GetState() != (int)PlayerStates.States.Damaged) &&
                (PlayerMachines.instance.GetPlayerStateMachine().GetState() != (int)PlayerStates.States.FallDamaged)) 
            {
                PlayerHealth.instance.SetHealth(PlayerHealth.instance.GetHealth() - collision.gameObject.GetComponent<EnemyAttack>().GetAttackDamage());
            }
            PlayerMachines.instance.GetPlayerStateMachine().SetEvent((int)PlayerStates.Events.Hit);
            PlayerMachines.instance.GetComboMachine().SetEvent((int)PlayerCombo.ComboEvents.StopCombo);
        }
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
