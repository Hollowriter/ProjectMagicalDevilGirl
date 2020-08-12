using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : SingletonBase<PlayerAttack>
{
    // Esta clase va a tener que ser refactoreada si o si.
    [SerializeField]
    GameObject attackBox; // Crear un script singleton aparte despues.
    Vector3 attackBoxVector; // Fijarme si lo puedo poner en otra funcion o script.
    public float attackHorizontalDifference;
    public float attackVerticalDifference;
    public float attackDuration; // Pendiente de modificar.
    float attackTime; // Modificar, despues va a depender de la animacion.
    int directionModifier; // Fijarme si lo puedo poner en otra funcion o script.

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        attackTime = 0;
        attackBox.SetActive(false);
        attackBoxVector = PlayerPosition.instance.GetPlayerPosition();
        directionModifier = 1;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void CheckDirection() 
    {
        if (!PlayerWalk.instance.GetDirection()) 
        {
            directionModifier = -1;
            return;
        }
        directionModifier = 1;
    }

    void Punch() 
    {
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.Punching)
        {
            attackBox.SetActive(true);
            attackBoxVector.x = PlayerPosition.instance.GetPlayerPosition().x + attackHorizontalDifference * directionModifier;
            attackBoxVector.y = PlayerPosition.instance.GetPlayerPosition().y + attackVerticalDifference;
            attackBox.transform.position = attackBoxVector;
        }
    }

    void CheckAttackTime() 
    {
        if (PlayerStates.instance.GetState() == (int)PlayerStates.States.Punching)
        {
            attackTime += Time.deltaTime;
            if (attackTime >= attackDuration) 
            {
                attackTime = 0;
                attackBox.SetActive(false);
                PlayerStates.instance.SetEvent(PlayerStates.Events.StopPunch);
            }
        }
    }

    protected override void BehaveSingleton()
    {
        CheckDirection();
        Punch();
        CheckAttackTime();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
