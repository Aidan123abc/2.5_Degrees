using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class backgroundLoopSimple : MonoBehaviour {
    //  private Transform centerBG;
      [SerializeField] private Transform centerBG;
      public float offset = 12;       //this value is the width of the image
      public GameObject player;

      void Update(){
            if (player.transform.position.x >= centerBG.position.x + offset){
                  centerBG.position = new Vector2(player.transform.position.x + offset, centerBG.position.y);
            }
            else if (player.transform.position.x <= centerBG.position.x - offset){
                  centerBG.position = new Vector2(player.transform.position.x - offset, centerBG.position.y);
            }
      }
}