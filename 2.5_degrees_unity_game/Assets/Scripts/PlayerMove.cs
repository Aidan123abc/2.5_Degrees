using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	private bool FaceRight = true;  // determine which way player is facing.
	public float runSpeed = 10f;
	private Animator animator;

	void Start()
	{
	// Get the Animator component
	animator = GetComponentInChildren<Animator>();
		if (animator == null) {
			Debug.LogError("Animator not found!");
		}
	}

	void Update ()
	{
	Vector3 hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
	transform.position += hMove * runSpeed * Time.deltaTime;

	// Update the Animator's Speed parameter
	//animator.SetFloat("Speed", runSpeed * Mathf.Abs(hMove.x));
	if (hMove.x != 0){
	animator.SetBool("Walk", true);
	} else {
		animator.SetBool("Walk", false);
	}

	if ((hMove.x < 0 && !FaceRight) || (hMove.x > 0 && FaceRight))
	{
		Turn();
	}
	}

	private void Turn()
	{
		// Switch player facing label
		FaceRight = !FaceRight;

		// Multiply player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}