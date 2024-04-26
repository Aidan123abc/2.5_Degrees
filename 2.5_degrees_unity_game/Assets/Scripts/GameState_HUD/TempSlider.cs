using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class tempSlider : MonoBehaviour
{

    public Slider slider;
    public float fillSpeed = 0.5f;
    private float targetProgress = .8f;
    public float startingLevel;


    private void Awake() {
        slider = gameObject.GetComponent<Slider>();

    }
    // Start is called before the first frame update
    void Start()
    {
        IncrementProgress(startingLevel);
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log("Target: " + targetProgress);
       if (slider.value != targetProgress) {
        slider.value += fillSpeed * Time.deltaTime;
       }

       
        
    }

    // adding to progress 
    public void IncrementProgress(float newProgress) {

        Debug.Log("PRGORESS?");
        targetProgress = slider.value += newProgress;
    }

    public void setProgress(float newProgress) {
        Debug.Log("setting to: " + newProgress);
        slider.value = newProgress;
        targetProgress = newProgress;
    }
}

