using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class backgroundLoopSimple : MonoBehaviour {
    //  private Transform centerBG;
      [SerializeField] private Transform centerBG;
      public float offset = 20;       //this value is the width of the image

      void Update(){
            if (transform.position.x >= centerBG.position.x + offset){
                  centerBG.position = new Vector2(transform.position.x + offset, centerBG.position.y);
            }
            else if (transform.position.x <= centerBG.position.x - offset){
                  centerBG.position = new Vector2(transform.position.x - offset, centerBG.position.y);
            }
      }
}