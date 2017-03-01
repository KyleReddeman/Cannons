using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody rigid;
	private float moveInput;
	private float turnInput;
	public float moveSpeed;
	public float turnSpeed;
	public float maxAngle;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		moveInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis("Horizontal");

	}

	void FixedUpdate() {
		rigid.AddForce(rigid.transform.forward * moveSpeed * moveInput);
		rigid.MoveRotation(rigid.rotation * Quaternion.Euler(0f, turnInput * turnSpeed * Time.deltaTime, 0f));
		Vector3 velocity = rigid.velocity;
		float angle = Vector3.Angle(velocity.normalized, rigid.transform.forward);
		if(velocity.magnitude > 5f && angle > maxAngle) {
			rigid.AddForce(-.8f * rigid.velocity);
		}
	}
}
