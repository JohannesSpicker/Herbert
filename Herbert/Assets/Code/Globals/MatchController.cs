using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MatchController : MonoBehaviour
{
	[SerializeField] private const int _scorePerCoin = 3;

	public int _startingHitpoints = 3;

	private int _hitpointsBackingField = 3;
	private int _scoreBackingField = 0;
	private int _coinBackingField = 0;

	public int _hitpoints
	{
		get => _hitpointsBackingField;
		set
		{
			_hitpointsBackingField = value;
			CanvasRefHolder.s_hitPointDisplay?.Invoke(value.ToString());
		}
	}
	public int _score
	{
		get => _scoreBackingField;
		set
		{
			_scoreBackingField = value;
			CanvasRefHolder.s_scoreDisplay?.Invoke(value.ToString());
		}
	}
	public int _coins
	{
		get => _coinBackingField;
		set
		{
			_coinBackingField = value;
			CanvasRefHolder.s_coinDisplay?.Invoke(value.ToString());
		}
	}


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

		Respawn(true);
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

	private void Respawn(bool atStart = false)
	{
		PlayerController player = GlobalRefHolder.s_instance._playerController;

		if (player != null)
		{
			player.StopAllMotion();

			if (atStart)
				GlobalRefHolder.s_instance._checkPointController?.ReturnPlayerToLevelStart();

			player.transform.position = GlobalRefHolder.s_instance._checkPointController.LastCheckPointPosition();
		}

		ResetHitPoints();
		GlobalRefHolder.s_instance._checkPointController?.RespawnEnemiesAtCurrentCheckPoint();
	}

	public void EndGame()
	{
		//GlobalRefHolder.s_instance._playerController?.gameObject.SetActive(false);
		GlobalRefHolder.s_instance._checkPointController?.DespawnAllEnemies();
		StartCoroutine(AddCoinsToScore());
	}

	private IEnumerator AddCoinsToScore()
	{
		while (0 < _coins)
		{
			_coins--;
			_score += _scorePerCoin;
			GlobalRefHolder.s_instance?._canvasRefHolder?.SetEndgameText(_coins.ToString(), _score.ToString());
			yield return new WaitForSeconds(0.25f);
		}

		Time.timeScale = 0f;
	}
}
