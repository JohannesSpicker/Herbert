using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private BoxCollider _hitboxCollider;
	private BoxCollider _bottomCollider;
	private bool _isJumping = false;
	private bool _isGrounded = true;

	[SerializeField] [Range(100f, 10000f)] private float _recoilMagnitude = 3000f;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_hitboxCollider = GetComponent<BoxCollider>();
		_bottomCollider = transform.GetChild(0).GetComponent<BoxCollider>();
	}

	void Update()
	{
		if (Input.GetButtonDown("MyJump"))
			Jump();
		if (Input.GetButton("MyLeft"))
			_rigidbody.AddForce(Vector3.left * 20f * (_isGrounded ? 2f : 0.5f));
		if (Input.GetButton("MyRight"))
			_rigidbody.AddForce(Vector3.right * 20f * (_isGrounded ? 2f : 0.5f));
	}

	public void StopAllMotion() => _rigidbody.velocity = Vector3.zero;

	private void Jump()
	{
		if (!_isGrounded || _isJumping)
			return;

		_isJumping = true;
		StartCoroutine(JumpCooldown());

		_rigidbody.AddForce(Vector3.up * 2500f);

	}

	IEnumerator JumpCooldown()
	{
		yield return new WaitForSeconds(0.2f);
		_isJumping = false;
	}
	public void SetGrounded(bool value) => _isGrounded = value;

	public void RecoilFromHit(Vector3 recoilDirection)
	{
		_rigidbody.velocity = Vector3.zero;
		_rigidbody.AddForce(recoilDirection.normalized * _recoilMagnitude);
	}
}
