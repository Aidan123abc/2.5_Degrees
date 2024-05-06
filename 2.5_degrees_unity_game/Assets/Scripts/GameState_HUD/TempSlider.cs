using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class tempSlider : MonoBehaviour
{

    public string sliderName; // Variable to hold the name of the slider
    public Slider slider;
    public float fillSpeed = 0.5f;
    private float targetProgress = .8f;
    public float startingLevel;

    public Color normalColor; // Store the normal color of the fill image
    public Color badColor = new Color(0.8f,0.3f,0.3f);
    public Image fill;


    private void Awake() {
        slider = gameObject.GetComponent<Slider>();

        sliderName = gameObject.name;
        normalColor = fill.color; // Store the initial color

    }
    // Start is called before the first frame update
    void Start()
    {
        //IncrementProgress(startingLevel);
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log("Target: " + targetProgress);
       Debug.Log("TEMPERATURE: " + slider.value);
       if (slider.value != targetProgress) {
        slider.value += fillSpeed * Time.deltaTime;
       }

        if ((slider.value < 0.3f) && (sliderName == "Helath Slider")) {
           if (fill != null) {
                fill.color = badColor;
           }
        } else if (sliderName == "Helath Slider") {
            fill.color = normalColor;
        }

         if ((slider.value > 0.51f) && (sliderName == "Temperature Slider")) {
           if (fill != null) {
                fill.color = badColor;
           }
        } else if (sliderName == "Temperature Slider") {
            Debug.Log("Temp IS: " + slider.value);
            fill.color = normalColor;
        }

        
        
    }

    // adding to progress 
    public void IncrementProgress(float newProgress) {

        //Debug.Log("PRGORESS?");
        targetProgress = slider.value += newProgress;
    }

    public void setProgress(float newProgress) {
        //Debug.Log("setting to: " + newProgress);
        slider.value = newProgress;
        targetProgress = newProgress;
    }
}

