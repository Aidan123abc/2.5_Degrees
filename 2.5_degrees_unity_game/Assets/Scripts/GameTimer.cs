using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Added this line

public class GameTimer : MonoBehaviour {
    public int timer = 0;
    private float theTimer = 0f;
    public GameObject timerText;
    public int temperature = 100;

    void FixedUpdate(){
        theTimer += 0.01f;
        if (theTimer >= 1f){
            timer +=1;
            theTimer = 0;
            UpdateTimer();
        }
    }

    void UpdateTimer(){
        Text timeTextTemp = timerText.GetComponent<Text>();
        timeTextTemp.text = "" + timer;
    }
}


