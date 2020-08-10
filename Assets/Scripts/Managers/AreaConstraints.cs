using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaConstraints : SingletonBase<AreaConstraints>
{
    public float LeftStageLimit;
    public float RightStageLimit;

    private void Awake()
    {
        SingletonAwake();
    }
}
