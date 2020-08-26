using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Linq;

public class CheckPointController : MonoBehaviour
{
	Vector3 _lastCheckPoint = Vector3.zero;
	CheckPoint[] _checkPoints;


	void Start()
	{
		//_checkPoints = FindObjectsOfType<CheckPoint>().OrderBy(check => check.transform.position.x) as CheckPoint[];
		_checkPoints = FindObjectsOfType<CheckPoint>();
		_checkPoints.OrderBy(check => check.transform.position.x);
	}

	void Update()
	{

	}

	public Vector3 LastCheckPoint() => _lastCheckPoint;
}
