using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

      private Rigidbody2D rb;
      private Animator animator;
      public float jumpForce = 20f;
      public Transform feet;
      public LayerMask groundLayer;
      public LayerMask enemyLayer; 
      public bool canJump = false; 
      public int jumpTimes = 0; 
      public bool isAlive = true;
      //public AudioSource JumpSFX; 
      

      void Start(){
            //anim = gameObject.GetComponentInChildren<Animator>(); 
            rb = GetComponent<Rigidbody2D>();

            animator = GetComponentInChildren<Animator>();
      }

     void Update() {
            
            if ((IsGrounded()) && (jumpTimes <= 1)){ // for single jump only
                  canJump = true;
                  animator.SetBool("Fly", false);
            } 
            else { // for single jump only
                  canJump = false;
                  animator.SetBool("Fly", true);
            }

           if ((Input.GetButtonDown("Jump")) && (canJump) && (isAlive == true)) {
                  Jump();
            }
      }

      void Jump() {
            jumpTimes += 1;
            rb.velocity = Vector2.up * jumpForce;
            // anim.SetTrigger("Jump");
            // JumpSFX.Play();

            //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            //rb.velocity = movement;
      } 

       bool IsGrounded() { 
            Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer);
            Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 0.5f, enemyLayer);
            if (groundCheck != null) //|| (enemyCheck != null)) 
            { 
                  // Debug.Log("I am trouching ground!");
                  jumpTimes = 0;
                  return true;
            }
            return false;
      }
}