using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxTriggerController : MonoBehaviour
{
	private PlayerController _playerController;

	void Start()
	{
		_playerController = GetComponentInParent<PlayerController>();
	}

	void Update()
	{

	}
	private void OnTriggerEnter(Collider other)
	{
		switch (other.tag)
		{
			case "Enemy":
				GlobalRefHolder.s_instance._matchcontroller?.LoseHitpoint();
				Vector3 enemyToPlayer = (transform.position - other.transform.position);
				GlobalRefHolder.s_instance._playerController?.RecoilFromHit(enemyToPlayer);
				EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();
				enemyMovement?.RecoilFromHit(-enemyToPlayer);
				break;
			default:
				break;
		}
	}
}
