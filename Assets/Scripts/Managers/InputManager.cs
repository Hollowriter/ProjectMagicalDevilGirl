using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonBase<InputManager>
{
    public KeyCode walkLeft { get; set; }
    public KeyCode walkRight { get; set; }
    public KeyCode jump { get; set; }
    public KeyCode attack { get; set; }

    public bool inputDetected()
    {
        if (Input.anyKey)
            return true;
        return false;
    }

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        walkLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        walkRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        attack = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attackKey", "J"));
    }

    void Awake()
    {
        SingletonAwake();
        DontDestroyOnLoad(gameObject);
    }
}
