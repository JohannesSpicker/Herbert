using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSinLeft : EnemyMovement
{
	[SerializeField] [Range(0f, 1f)] float _sinMagnitude = 0.5f;
	[SerializeField] [Range(0.1f, 10f)] float _sinFrequency = 1f;

	protected override void Move()
	{
		_rigidbody.AddForce(Vector3.left * _speed * (1 + _sinMagnitude * Mathf.Sin(_sinFrequency * Time.time)));
	}
}
