using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : SingletonBase<CameraFollower>
{
    Vector3 moveVector;
    Vector3 playerOnScreen;
    float camVertExtent;
    float camHorzExtent;
    float leftConstraint;
    float rightConstraint;
    float topConstraint;
    float bottomConstraint;
    public float playerCameraLimitRight;
    public float playerCameraLimitLeft;
    public float playerCameraLimitUp;
    public float playerCameraLimitDown;
    public float cameraTranslationSpeed;

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
        playerOnScreen = Vector3.zero;
        CalculateCameraLimits();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    bool CheckIfPlayerIsInCamera() 
    {
        playerOnScreen = this.GetComponent<Camera>().WorldToViewportPoint(PlayerPosition.instance.transform.position);
        if (playerOnScreen.x > playerCameraLimitLeft && playerOnScreen.x < playerCameraLimitRight && playerOnScreen.y > playerCameraLimitDown && playerOnScreen.y < playerCameraLimitUp) 
        {
            return true;
        }
        return false;
    }

    void FollowX() 
    {
        if (playerOnScreen.x < playerCameraLimitLeft) 
        {
            moveVector.x -= cameraTranslationSpeed * Time.deltaTime;
        }
        else if (playerOnScreen.x > playerCameraLimitRight) 
        {
            moveVector.x += cameraTranslationSpeed * Time.deltaTime;
        }
        moveVector.x = Mathf.Clamp(moveVector.x, leftConstraint, rightConstraint);
    }

    void FollowY() 
    {
        if (playerOnScreen.y < playerCameraLimitDown)
        {
            moveVector.y -= cameraTranslationSpeed * Time.deltaTime;
        }
        else if (playerOnScreen.y > playerCameraLimitUp)
        {
            moveVector.y += cameraTranslationSpeed * Time.deltaTime;
        }
        moveVector.y = Mathf.Clamp(moveVector.y, leftConstraint, rightConstraint);
    }

    void Follow()
    {
        if (!CheckIfPlayerIsInCamera()) 
        {
            FollowX();
            FollowY();
        }
        moveVector.z = this.gameObject.transform.position.z;
        transform.position = moveVector;
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
