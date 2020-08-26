using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalRefHolder : Singleton<GlobalRefHolder>
{
	public PlayerController _playerController;

	public MatchController _matchcontroller;
	public CheckPointController _checkPointController;

	void Start()
	{
		_playerController = FindObjectOfType<PlayerController>();

		SetFieldOrAddComponentIfNull<MatchController>(ref _matchcontroller);
		SetFieldOrAddComponentIfNull<CheckPointController>(ref _checkPointController);
	}

	void Update()
	{

	}

	private void SetFieldOrAddComponentIfNull<T>(ref T field) where T : MonoBehaviour
	{
		if (field != null)
			return;

		field = GetComponent<T>();

		if (field == null)
			field = gameObject.AddComponent<T>();
	}
}
