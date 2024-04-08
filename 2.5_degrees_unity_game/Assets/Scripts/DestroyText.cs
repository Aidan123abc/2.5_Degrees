using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyText : MonoBehaviour
{
    
    public float DestroyTime = 3f;
    public string noAcornsText = "You have no acorns! Collect more!";

    // Start is called before the first frame update
    void Start()
    {
       TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();
        if (textMesh != null)
        {
            // Set the text of the TextMeshProUGUI component
            textMesh.text = noAcornsText;
        }

        Destroy(gameObject, DestroyTime);
        
    }

}
