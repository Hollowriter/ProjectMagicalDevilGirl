using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : SingletonBase<ExitButton>
{
    private void Awake()
    {
        SingletonAwake();
    }

    public void PressExit() 
    {
        Application.Quit();
    }
}
