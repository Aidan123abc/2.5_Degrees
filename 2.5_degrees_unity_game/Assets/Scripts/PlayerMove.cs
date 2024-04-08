using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	private bool FaceRight = true;  // determine which way player is facing.
	public float runSpeed = 10f;
	private Animator animator;
	public GameHandler gameHandler;

	void Start()
	{
	// Get the Animator component
	animator = GetComponentInChildren<Animator>();
		if (animator == null) {
			Debug.LogError("Animator not found!");
		}

		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
	}

	void Update ()
	{
	Vector3 hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
	transform.position += hMove * runSpeed * Time.deltaTime;

	// // 'E' eats acorns 
	// if (Input.GetKeyDown(KeyCode.E))
    // {
    //     eat();
	// 	animator.SetBool("Eat", true);
    // } else {animator.SetBool("Eat", false);}

	// // 'P' plants trees 
	// if (Input.GetKeyDown(KeyCode.P)) 
	// {
	// 	plant();
	// 	animator.SetBool("Plant", true);
	// } else {animator.SetBool("Plant", false);}


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

	// // void eat() 
	// // {
	// // 	int value = GameHandler.acorns;
	// // 	Debug.Log("acorns: " + value);
	// // 	if (value >= 1) {
	// // 		gameHandler.playerGetHit(-2);
	// // 		GameHandler.acorns = GameHandler.acorns - 1;
	// // 	} else {
	// // 		Debug.Log("There are no acorns to eat! Collect more!");
	// // 	}
		
	// // }

	// // void plant()
	// // {
	// // 	int value = GameHandler.acorns;
	// // 	if (value > 0) {
	// // 		GameHandler.temp = GameHandler.temp - 1;
	// // 		GameHandler.acorns = GameHandler.acorns - 1;
	// 	}
	

	// }


}

	
