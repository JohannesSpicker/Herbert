﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
	protected Rigidbody _rigidbody;

	[SerializeField] [Range(1f, 100f)] protected float _speed = 10f;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();

		if (null == _rigidbody)
			_rigidbody = gameObject.AddComponent<Rigidbody>();
	}

	private void OnEnable()
	{
		Initialise();
	}

	private void Update()
	{
		Move();
	}

	protected virtual void Initialise()
	{

	}

	protected virtual void Move()
	{
		_rigidbody.AddForce(Vector3.left * 10f);
	}
}
