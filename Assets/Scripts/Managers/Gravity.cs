using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : SingletonBase<Gravity>
{
    public float gravity;

    private void Awake()
    {
        SingletonAwake();
    }
}
