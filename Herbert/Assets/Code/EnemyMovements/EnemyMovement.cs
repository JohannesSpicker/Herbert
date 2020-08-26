using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public virtual void Move(Rigidbody rigidbody)
	{
		rigidbody.AddForce(Vector3.left * 10f);
	}
}
