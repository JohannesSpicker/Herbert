using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHopJump : EnemyMovement
{
	private IEnumerator _coroutine;

	protected override void Initialise()
	{
		_coroutine = JumpRoutine();
		StartCoroutine(_coroutine);
	}

	protected override void Move()
	{

	}

	private IEnumerator JumpRoutine()
	{
		while (isActiveAndEnabled)
		{
			_rigidbody.AddForce(_speed * Vector3.up * 150f);
			_rigidbody.AddForce(_speed * Vector3.left * 15f);
			yield return new WaitForSeconds(1.5f);
			_rigidbody.AddForce(_speed * Vector3.up * 150f);
			_rigidbody.AddForce(_speed * Vector3.left * 15f);
			yield return new WaitForSeconds(1.5f);
			_rigidbody.AddForce(_speed * Vector3.up * 150f);
			_rigidbody.AddForce(_speed * Vector3.left * 15f);
			yield return new WaitForSeconds(1.5f);
			_rigidbody.AddForce(_speed * Vector3.up * 250f);
			_rigidbody.AddForce(_speed * Vector3.left * 5f);
			yield return new WaitForSeconds(2.5f);
		}
	}

	private void OnDisable()
	{
		StopCoroutine(_coroutine);
	}
}
