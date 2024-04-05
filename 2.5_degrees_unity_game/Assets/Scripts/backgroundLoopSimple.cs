using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class backgroundLoopSimple : MonoBehaviour {
      private Transform centerBG;
      public float offset = 10f;       //this value is the width of the image

      void Update(){
            if (transform.position.x >= centerBG.position.x + offset){
                  centerBG.positon = new Vector2(transform.position.x + offset, centerBG.position.y);
            }
            else if (transform.position.x <= centerBG.position.x - offset){
                  centerBG.positon = new Vector2(transform.position.x - offset, centerBG.position.y);
            }
      }
}