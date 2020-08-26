﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MatchController : MonoBehaviour
{
	public int _startingHitpoints = 3;
	public int _hitpoints;

	public int _score = 0;
	public int _coins = 0;

	void Start()
	{
		ResetMatch();
	}

	void Update()
	{

	}

	public void LoseHitpoint()
	{
		_hitpoints--;

		if (_hitpoints <= 0)
			Die();
	}

	public void ResetHitPoints() => _hitpoints = _startingHitpoints;

	public void ResetMatch()
	{
		_hitpoints = _startingHitpoints;
		_score = 0;
		_coins = 0;

		//reset enemies
		//reset coin objects
	}

	public void Die()
	{
		Respawn();
	}

	public void AddScore(int value)
	{
		_score += value;
	}

	public void AddCoins(int value)
	{
		_coins += value;
	}

	private void Respawn()
	{
		PlayerController player = GlobalRefHolder.s_instance._playerController;

		if (player != null)
		{
			player.StopAllMotion();
			player.transform.position = GlobalRefHolder.s_instance._checkPointController.LastCheckPointPosition();
		}

		ResetHitPoints();
		GlobalRefHolder.s_instance._checkPointController?.RespawnEnemiesAtCurrentCheckPoint();
	}
}
