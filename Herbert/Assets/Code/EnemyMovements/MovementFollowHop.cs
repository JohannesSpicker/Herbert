using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFollowHop : EnemyMovement
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
			if (null != GlobalRefHolder.s_instance._playerController)
				_rigidbody.AddForce(_speed * 15f * (GlobalRefHolder.s_instance._playerController.transform.position.x < transform.position.x ? Vector3.left : Vector3.right));
			yield return new WaitForSeconds(1.5f);
		}
	}

	private void OnDisable()
	{
		StopCoroutine(_coroutine);
	}
}
