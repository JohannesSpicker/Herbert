using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFollow : EnemyMovement
{
	protected override void Move()
	{
		if (GlobalRefHolder.s_instance._playerController != null)
		{
			_rigidbody.AddForce((GlobalRefHolder.s_instance._playerController.transform.position - transform.position).normalized * _speed);
		}
	}
}
