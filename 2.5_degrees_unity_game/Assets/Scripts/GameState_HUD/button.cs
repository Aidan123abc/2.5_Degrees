using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    public Button myButton;  // Assign this in the inspector
    public int offValue;

    void Start()
    {
        //myButton.interactable(false);  // Example call to disable the button on start
    }

    void Update() {
        if (GameHandler.acorns < offValue) {
            myButton.interactable = false;
        } else {
            myButton.interactable = true; 
        }
    }

    // // Method to toggle the button's interactivity and visual state
    // public void ToggleButton(bool isEnabled)
    // {
    //     myButton.interactable = isEnabled;  // Set the button's interactable state
    //     //myButton.GetComponent<Image>().color = isEnabled ? Color.white : Color.grey;  // Change color to grey when disabled, white when enabled
    // }
}