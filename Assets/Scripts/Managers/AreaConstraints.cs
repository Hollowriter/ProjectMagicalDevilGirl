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

    public void SetLeftStageLimit(float _LeftStageLimit) 
    {
        LeftStageLimit = _LeftStageLimit;
    }

    public void SetRightStageLimit(float _RightStageLimit) 
    {
        RightStageLimit = _RightStageLimit;
    }

    public void SetTopStageLimit(float _TopStageLimit) 
    {
        TopStageLimit = _TopStageLimit;
    }

    public void SetBottomStageLimit(float _BottomStageLimit) 
    {
        BottomStageLimit = _BottomStageLimit;
    }
}
