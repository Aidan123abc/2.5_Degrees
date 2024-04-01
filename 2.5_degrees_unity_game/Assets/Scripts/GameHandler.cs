using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void playerGetHit(int damage){
        //    if (isDefending == false){
        //           playerHealth -= damage;
        //           if (playerHealth >=0){
        //                 updateStatsDisplay();
        //           }
        //           if (damage > 0){
        //                 player.GetComponent<PlayerHurt>().playerHit();       //play GetHit animation
        //           }
        //     }

        //    if (playerHealth > StartPlayerHealth){
        //           playerHealth = StartPlayerHealth;
        //           updateStatsDisplay();
        //     }

        //    if (playerHealth <= 0){
        //           playerHealth = 0;
        //           updateStatsDisplay();
        //           playerDies();
        //     }
        Debug.Log("ouch!");
      }
}
