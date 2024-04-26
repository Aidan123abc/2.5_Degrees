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
    public Color badColor = new Color(0.8f,0.3f,0.3f);
    public Image fill;


    private void Awake() {
        slider = gameObject.GetComponent<Slider>();

    }
    // Start is called before the first frame update
    void Start()
    {
        //IncrementProgress(startingLevel);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Target: " + targetProgress);
       if (slider.value != targetProgress) {
        slider.value += fillSpeed * Time.deltaTime;
       }

        if (slider.value < 0.5f) {
           if (fill != null) {
                fill.color = badColor;
           }
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

