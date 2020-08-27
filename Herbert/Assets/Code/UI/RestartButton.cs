using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
	public void RestartLevel()
	{
		Time.timeScale = 1f;
		GlobalRefHolder.s_instance._matchcontroller?.ResetMatch();
		transform.parent?.gameObject.SetActive(false);
	}
}
