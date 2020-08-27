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

	private TMP_Text _hitPointText;
	private TMP_Text _coinText;
	private TMP_Text _scoreText;

	void Start()
	{
		_hitPointText = transform.GetChild(0)?.GetComponent<TMP_Text>();
		_coinText = transform.GetChild(1)?.GetComponent<TMP_Text>();
		_scoreText = transform.GetChild(2)?.GetComponent<TMP_Text>();
	}

	public void SetHitPointText(string content) => _hitPointText.text = "Hitpoints: " + content;
	public void SetCoinText(string content) => _coinText.text = "Coins: " + content;
	public void SetScoreText(string content) => _scoreText.text = "Score: " + content;

	private void OnEnable()
	{
		s_hitPointDisplay += SetHitPointText;
		s_coinDisplay += SetCoinText;
		s_scoreDisplay += SetScoreText;
	}

	private void OnDisable()
	{
		s_hitPointDisplay -= SetHitPointText;
		s_coinDisplay -= SetCoinText;
		s_scoreDisplay -= SetScoreText;
	}
}
