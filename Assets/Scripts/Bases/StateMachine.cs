using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    int[,] machine;
    int state;

    public void Init(int statesCount, int eventCount)
    {
        machine= new int[statesCount, eventCount];

        for (int i = 0; i < statesCount; i++)
        {
            for (int o = 0; o < eventCount; o++)
            {
                machine[i, o] = -1;
            }
        }
    }

    public void SetRelation(int srcState, int evt, int dsrState)
    {
        machine[srcState, evt] = dsrState;
    }

    public int GetState()
    {
        return state;
    }

    public void SetEvent(int evt)
    {
        if (machine[state, evt] != -1)
        {
            state = machine[state, evt];
        }
    }
}
