using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

      public GameHandler gameHandler;
      //public playerVFX playerPowerupVFX; 
      public bool isHealthPickUp = true;
      public AudioSource sound;

      public int healthBoost = 5;
    

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>(); 
      }

      public void OnTriggerEnter2D (Collider2D other){ 
            if (other.gameObject.tag == "Player"){ 
                  GetComponent<Collider2D>().enabled = false; 
                  // sound = GetComponent< AudioSource>();
                  sound.Play();
                  StartCoroutine(DestroyThis());

                  if (isHealthPickUp == true) {
                        //gameHandler.playerGetHit(healthBoost * -1);       // gives health
                        //playerPowerupVFX.powerup();
                        gameHandler.playerPickUp(1);
                  }

                  
            }
      } 

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
      }

}