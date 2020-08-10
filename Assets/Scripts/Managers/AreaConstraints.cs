using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaConstraints : SingletonBase<AreaConstraints>
{
    public float LeftStageLimit;
    public float RightStageLimit;
    public float TopStageLimit;
    public float BottomStageLimit;

    private void Awake()
    {
        SingletonAwake();
    }
}
