using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    public Animator anim;
       public Rigidbody2D rb2D;
       public float speed = 4f;
       private Transform target;
       public int damage = 10;

       public int EnemyLives = 3;
       private GameHandler gameHandler;


       public float attackRange = 10;
       public bool isAttacking = false;
       private float scaleX;
       public float knockBackForce = 20f;

       void Start () {
              anim = GetComponentInChildren<Animator> ();
              rb2D = GetComponent<Rigidbody2D> ();
              // scaleX = gameObject.transform.localScale.x;

              if (GameObject.FindGameObjectWithTag ("Player") != null) {
                     target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
              }

              if (GameObject.FindWithTag ("GameHandler") != null) {
                  gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
                  Debug.Log("Component found");
              } else {
                  Debug.Log("Null");
              }
       }
       void FixedUpdate() {
//               float DistToPlayer = Vector3.Distance(transform.position, target.position);

// //             
// // transform.position = MovePos;

//               if ((target != null) && (DistToPlayer <= attackRange)){
//                       Debug.Log("I see you");
//                      transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
//                     //anim.SetBool("Walk", true);
//                     //flip enemy to face player direction. Wrong direction? Swap the * -1.
//                     if (target.position.x > gameObject.transform.position.x){
//                                    gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
//                     } else {
//                                     gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
//                     }
//               }
              //  else {anim.SetBool("Walk", true); }
       }

       public void OnCollisionEnter2D(Collision2D other){
              if (other.gameObject.tag == "Player") {
                     isAttacking = true;
                     //anim.SetBool("Attack", true);
                     gameHandler.playerGetHit(damage);
                     anim.SetTrigger("attack");
                     if (target.position.x > transform.position.x) {
                         NPC_PatrolSequencePoints location = GetComponent<NPC_PatrolSequencePoints>();
                         location.NPCTurn();
                     }
                     //Add force to the player, pushing them back without teleporting:
                    //  Debug.Log("Knockback time");
                    // float pushBack = 0f;
                    //  if (other.gameObject.transform.position.x > gameObject.transform.position.x){
                    //         pushBack = 3f;
                    //  }
                    //  else {
                    //         pushBack = -3f;
                    //  }
                    //  other.gameObject.transform.position = new Vector3(transform.position.x + pushBack, transform.position.y + 1, 0);
              }
       }

       public void OnCollisionExit2D(Collision2D other){
              if (other.gameObject.tag == "Player") {
                     isAttacking = false;
                     anim.ResetTrigger("attack");
                     //anim.SetBool("Attack", false);
              }
       }

       //DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, attackRange);
       }
}
