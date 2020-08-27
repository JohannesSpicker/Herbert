using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public int _scoreValue = 5;

	public void Die()
	{
		GlobalRefHolder.s_instance._matchcontroller?.AddScore(_scoreValue);
		gameObject.SetActive(false);
	}
}
