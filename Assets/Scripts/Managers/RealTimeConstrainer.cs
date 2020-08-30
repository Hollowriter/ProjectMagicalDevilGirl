using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeConstrainer : SingletonBase<RealTimeConstrainer>
{
    bool direction;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        direction = true;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void LeftConstrain() 
    {
        if (direction)
            AreaConstraints.instance.SetLeftStageLimit(AreaConstraints.instance.LeftStageLimit + CameraFollower.instance.cameraTranslationSpeed * Time.deltaTime);
    }

    public void RightConstrain() 
    {
        if (!direction)
            AreaConstraints.instance.SetRightStageLimit(AreaConstraints.instance.RightStageLimit - CameraFollower.instance.cameraTranslationSpeed * Time.deltaTime);
    }

    public void SetDirection(bool _direction)
    {
        direction = _direction;
    }

    public void Deconstrain(int _deconstrainValue) 
    {
        if (direction) 
        {
            AreaConstraints.instance.SetRightStageLimit(AreaConstraints.instance.RightStageLimit + _deconstrainValue);
            return;
        }
        AreaConstraints.instance.SetLeftStageLimit(AreaConstraints.instance.LeftStageLimit - _deconstrainValue);
    }
}
