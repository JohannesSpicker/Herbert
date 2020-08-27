using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CanvasRefHolder : MonoBehaviour
{
	public static Action<string> s_hitPointDisplay;
	public static Action<string> s_coinDisplay;
	public static Action<string> s_scoreDisplay;
	public static Action<string, string> s_endgameDisplay;

	private TMP_Text _hitPointText;
	private TMP_Text _coinText;
	private TMP_Text _scoreText;
	private TMP_Text _endgameText;

	private GameObject _endgamePanel;

	void Start()
	{
		_hitPointText = transform.GetChild(0)?.GetComponent<TMP_Text>();
		_coinText = transform.GetChild(1)?.GetComponent<TMP_Text>();
		_scoreText = transform.GetChild(2)?.GetComponent<TMP_Text>();
		_endgameText = transform.GetChild(3)?.GetChild(0)?.GetComponent<TMP_Text>();
		_endgamePanel = transform.GetChild(3).gameObject;
	}

	public void SetHitPointText(string content) => _hitPointText.text = "Hitpoints: " + content;
	public void SetCoinText(string content) => _coinText.text = "Coins: " + content;
	public void SetScoreText(string content) => _scoreText.text = "Score: " + content;
	public void SetEndgameText(string coins, string score)
	{
		_endgamePanel?.SetActive(true);
		if (_endgameText != null)
			_endgameText.text = "Coins: " + coins + "\n" + "Score: " + score;
	}

	private void OnEnable()
	{
		s_hitPointDisplay += SetHitPointText;
		s_coinDisplay += SetCoinText;
		s_scoreDisplay += SetScoreText;
		s_endgameDisplay += SetEndgameText;
	}

	private void OnDisable()
	{
		s_hitPointDisplay -= SetHitPointText;
		s_coinDisplay -= SetCoinText;
		s_scoreDisplay -= SetScoreText;
		s_endgameDisplay -= SetEndgameText;
	}
}
