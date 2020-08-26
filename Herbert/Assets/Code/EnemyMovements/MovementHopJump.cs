using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHopJump : EnemyMovement
{
	protected override void Initialise()
	{
		StartCoroutine(JumpRoutine());
	}

	protected override void Move()
	{
		_rigidbody.AddForce(Vector3.left * 10f);
		_rigidbody.AddForce(Vector3.left * 5f);
	}

	private IEnumerator JumpRoutine()
	{
		while (isActiveAndEnabled)
		{
			yield return new WaitForSeconds(1f);
			_rigidbody.AddForce(Vector3.up * 2000f);
		}

		yield return null;
	}
}
