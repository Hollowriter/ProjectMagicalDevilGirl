using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
	[SerializeField]
	float jumpSpeed;
	[SerializeField]
	float jumpTime;
	float jumpPosition;
	float jumpTimer;

	void Begin()
	{
		jumpPosition = GetComponent<EnemyPosition>().GetEnemyPositionY();
		jumpTimer = 0;
	}

	void Awake()
	{
		Begin();
	}

	void GravityActing()
	{
		jumpPosition = GetComponent<EnemyPosition>().GetEnemyPositionY();
		jumpPosition -= Gravity.instance.gravity * Time.deltaTime;
	}

	void ApplyJump()
	{
		GetComponent<EnemyPosition>().SetEnemyPositionY(jumpPosition);
	}

	public void UpdateGravity()
	{
		GravityActing();
		ApplyJump();
	}
}
