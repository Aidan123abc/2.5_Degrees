using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyBounds : MonoBehaviour {

       public float speed = 2f;
       private Rigidbody2D rb;
       //private Animator anim;
       public LayerMask groundLayers;
       public Transform groundCheck;
       bool faceRight = true;
       RaycastHit2D hit;

       public int damage = 10;
       private GameHandler gameHandler;

       void Start(){
              rb = GetComponent<Rigidbody2D>();
              //anim.SetBool("Walk", true);
              if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
       }

       void Update(){
              hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groundLayers);
       }

       void FixedUpdate(){
              if (hit.collider != false){
                     if (faceRight){
                            rb.velocity = new Vector2(speed, rb.velocity.y);
                     } else {
                            rb.velocity = new Vector2(-speed, rb.velocity.y);
                     }
              } else {
                     faceRight = !faceRight;
                     transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
              }
       }

};