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
            if (PlayerStates.instance.GetState() == (int)PlayerStates.States.Punching) 
            {
                PlayerStates.instance.SetEvent(PlayerStates.Events.LandPunch); // Pendientes de hacer los combos.
            }
        }
    }
}
