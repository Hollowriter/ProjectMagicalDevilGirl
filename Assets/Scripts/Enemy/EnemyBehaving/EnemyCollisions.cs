using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    EnemyStates enemyStates;

    void Begin() 
    {
        enemyStates = GetComponent<EnemyStates>();
    }

    private void Awake()
    {
        Begin();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack") 
        {
            if (PlayerMachines.instance.GetComboMachine().GetState() == (int)PlayerCombo.ComboStates.ThirdPunch ||
                PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickIdle ||
                PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickLeft ||
                PlayerMachines.instance.GetPlayerStateMachine().GetState() == (int)PlayerStates.States.AirKickRight) 
            {
                enemyStates.SetEvent((int)EnemyStates.BaddieEvents.Fall);
                return;
            }
            enemyStates.SetEvent((int)EnemyStates.BaddieEvents.Hit);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            enemyStates.SetEvent((int)EnemyStates.BaddieEvents.Grounded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            enemyStates.SetEvent((int)EnemyStates.BaddieEvents.NoFloor);
        }
    }
}
