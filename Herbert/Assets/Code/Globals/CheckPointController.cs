using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EnemyTypes { Follow, HopJump, SinLeft, FollowHop };

public class CheckPointController : MonoBehaviour
{
	CheckPoint _lastCheckPoint;
	CheckPoint[] _checkPoints;
	Dictionary<CheckPoint, List<EnemyPlaceholder>> _placeholderDict = new Dictionary<CheckPoint, List<EnemyPlaceholder>>();
	Dictionary<CheckPoint, List<GameObject>> _enemyDict = new Dictionary<CheckPoint, List<GameObject>>();

	[SerializeField] private GameObject _enemyFollow;
	[SerializeField] private GameObject _enemyHopJump;
	[SerializeField] private GameObject _enemySinLeft;
	[SerializeField] private GameObject _enemyFollowHop;

	void Start()
	{
		_checkPoints = FindObjectsOfType<CheckPoint>();
		_checkPoints = _checkPoints.OrderByDescending(check => -check.transform.position.x).ToArray();
		if (0 < _checkPoints.Length)
			_lastCheckPoint = _checkPoints[0];

		_placeholderDict.Clear();
		_enemyDict.Clear();

		foreach (CheckPoint check in _checkPoints)
		{
			_placeholderDict[check] = new List<EnemyPlaceholder>();
			_enemyDict[check] = new List<GameObject>();
		}

		foreach (EnemyPlaceholder enemy in FindObjectsOfType<EnemyPlaceholder>())
		{
			for (int i = 0; i < _checkPoints.Length - 1; i++)
			{
				if (enemy.transform.position.x < _checkPoints[i + 1].transform.position.x)
				{
					_placeholderDict[_checkPoints[i]].Add(enemy);
					break;
				}
			}

			enemy.gameObject.SetActive(false);
		}

		if (0 < _checkPoints.Length && null != _enemyDict[_checkPoints[0]])
			SpawnEnemiesOfCheckPoint(_checkPoints[0]);
	}

	void Update()
	{

	}

	public Vector3 LastCheckPointPosition() => _lastCheckPoint != null ? _lastCheckPoint.transform.position : Vector3.zero;

	public void CheckPointReached(CheckPoint checkPoint)
	{
		if (_lastCheckPoint == null || _lastCheckPoint.transform.position.x <= checkPoint.transform.position.x)
		{
			_lastCheckPoint = checkPoint;
			SpawnEnemiesOfCheckPoint(checkPoint);
		}

		if (checkPoint == _checkPoints[_checkPoints.Length - 1])
		{
			//wincondition
		}
	}

	public void SpawnEnemiesOfCheckPoint(CheckPoint check)
	{
		if (check == null)
			return;

		foreach (GameObject enemy in _enemyDict[check])
			Destroy(enemy, 0.1f);

		_enemyDict[check].Clear();

		foreach (EnemyPlaceholder enemy in _placeholderDict[check])
			_enemyDict[check].Add(Instantiate(EnemyPrefabFromType(enemy._enemyType), enemy.transform.position, Quaternion.identity));
	}

	public void RespawnEnemiesAtCurrentCheckPoint() => SpawnEnemiesOfCheckPoint(_lastCheckPoint);

	private GameObject EnemyPrefabFromType(EnemyTypes type)
	{
		switch (type)
		{
			case EnemyTypes.Follow:
				return _enemyFollow;
			case EnemyTypes.HopJump:
				return _enemyHopJump;
			case EnemyTypes.SinLeft:
				return _enemySinLeft;
			case EnemyTypes.FollowHop:
				return _enemyFollowHop;
			default:
				return new GameObject();
		}
	}
}
