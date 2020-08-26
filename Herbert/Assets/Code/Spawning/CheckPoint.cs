using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	public bool _reached = false;

	Material _material;

	private void Awake()
	{
		_material = GetComponent<Renderer>()?.material;
	}

	void Start()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player" || _reached == true)
			return;

		_reached = true;
		if (_material != null)
			_material.color = Color.green;
		GlobalRefHolder.s_instance._checkPointController?.CheckPointReached(this);
	}
}
