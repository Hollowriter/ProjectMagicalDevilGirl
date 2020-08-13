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
            PlayerStates.instance.SetEvent(PlayerStates.Events.Landed);
            PlayerCombo.instance.SetEvent(PlayerCombo.ComboEvents.Grounded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            PlayerStates.instance.SetEvent(PlayerStates.Events.FallUngrounded);
            PlayerCombo.instance.SetEvent(PlayerCombo.ComboEvents.OnAir);
        }
    }
}
