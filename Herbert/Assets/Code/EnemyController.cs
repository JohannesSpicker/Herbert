using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
	public int _scoreValue = 5;

	private EnemyMovement _movement;
	private Rigidbody _rigidbody;

	void Start()
	{
		_movement = GetComponent<EnemyMovement>();
		_rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (_rigidbody != null)
			_movement?.Move(_rigidbody);
	}

	public void Die()
	{
		GlobalRefHolder.s_instance._matchcontroller?.AddScore(_scoreValue);
		gameObject.SetActive(false);
	}
}
