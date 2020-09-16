using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : SingletonBase<StartButton>
{
    private void Awake()
    {
        SingletonAwake();
    }

    public void PressStart()
    {
        SceneManager.LoadScene("Bank");
    }
}
