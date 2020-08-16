using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonStates : SingletonBase<SingletonStates>
{
    protected StateMachine stateMachine;

    protected virtual void RelationsBegin() 
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
