using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	Rigidbody _rigidBody;
	BoxCollider _hitboxCollider;
	BoxCollider _bottomCollider;
	bool _isJumping = false;
	public bool _isGrounded = true;

	// Start is called before the first frame update
	void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
		_hitboxCollider = GetComponent<BoxCollider>();
		_bottomCollider = transform.GetChild(0).GetComponent<BoxCollider>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("MyJump"))
			Jump();
		if (Input.GetButton("MyLeft"))
			_rigidBody.AddForce(Vector3.left * 10f);
		if (Input.GetButton("MyRight"))
			_rigidBody.AddForce(Vector3.right * 10f);
	}

	private void Jump()
	{
		if (!_isGrounded || _isJumping)
			return;

		_isJumping = true;
		StartCoroutine(JumpCooldown());

		_rigidBody.AddForce(Vector3.up * 2000f);

	}

	IEnumerator JumpCooldown()
	{
		yield return new WaitForSeconds(0.2f);
		_isJumping = false;
	}
	public void SetGrounded(bool value) => _isGrounded = value;

}
