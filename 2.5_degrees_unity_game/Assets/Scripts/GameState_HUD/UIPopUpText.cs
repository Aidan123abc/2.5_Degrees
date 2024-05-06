using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPopUpText : MonoBehaviour
{
    
    public float DestroyTime = 3f;
    public string noTemp = "Plant more trees and lower the global temperature to visit this island!";

    // Start is called before the first frame update
    void Start()
    {
       TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();
        if (textMesh != null)
        {
            // Set the text of the TextMeshProUGUI component
            textMesh.text = noTemp;
        }

        Destroy(gameObject, DestroyTime);
        
    }

}
