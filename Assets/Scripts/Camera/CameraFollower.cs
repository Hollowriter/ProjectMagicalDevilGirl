using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : SingletonBase<CameraFollower>
{
    Vector3 moveVector;
    float camVertExtent;
    float camHorzExtent;
    float leftConstraint;
    float rightConstraint;
    float topConstraint;
    float bottomConstraint;

    void CalculateCameraLimits()
    {
        camVertExtent = this.gameObject.GetComponent<Camera>().orthographicSize;
        camHorzExtent = this.gameObject.GetComponent<Camera>().aspect * camVertExtent;
        leftConstraint = AreaConstraints.instance.LeftStageLimit + camHorzExtent;
        rightConstraint = AreaConstraints.instance.RightStageLimit - camHorzExtent;
        topConstraint = AreaConstraints.instance.TopStageLimit - camVertExtent;
        bottomConstraint = AreaConstraints.instance.BottomStageLimit - camVertExtent;
    }

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        moveVector = Vector3.zero;
        CalculateCameraLimits();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void Follow()
    {
        if (Input.GetKey(InputManager.instance.walkLeft) || Input.GetKey(InputManager.instance.walkRight))
        {
            moveVector.x = Mathf.Clamp(PlayerPosition.instance.transform.position.x, leftConstraint, rightConstraint);
            moveVector.y = Mathf.Clamp(PlayerPosition.instance.transform.position.y, bottomConstraint, topConstraint);
            moveVector.z = this.gameObject.transform.position.z;
            transform.position = moveVector;
        }
    }

    protected override void BehaveSingleton()
    {
        Follow();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
