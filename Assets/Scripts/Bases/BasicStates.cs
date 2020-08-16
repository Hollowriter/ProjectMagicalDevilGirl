using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStates : MonoBehaviour
{
    protected StateMachine stateMachine;

    protected void StartMachine(int numberStates, int numberEvents) 
    {
        stateMachine = new StateMachine();
        stateMachine.Init(numberStates, numberEvents);
    }

    protected virtual void RelationsBegin()
    {
    }

    protected virtual void Begin() 
    { 
    }

    public void SetEvent(int theEvent)
    {
        stateMachine.SetEvent(theEvent);
    }

    public int GetState()
    {
        return stateMachine.GetState();
    }
}
