using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomTriggerController : MonoBehaviour
{
	private PlayerController _playerController;

	// Start is called before the first frame update
	void Start()
	{
		_playerController = GetComponentInParent<PlayerController>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		switch (other.tag)
		{
			case "Enemy":
				break;
			case "Ground":
				_playerController.SetGrounded(true);
				break;
			default:
				break;
		}
	}

	private void OnTriggerStay(Collider other)
	{

		_playerController.SetGrounded(true);

		switch (other.tag)
		{
			case "Ground":
				_playerController.SetGrounded(true);
				break;
			default:
				break;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		switch (other.tag)
		{
			case "Ground":
				_playerController.SetGrounded(false);
				break;
			default:
				break;
		}
	}
}
