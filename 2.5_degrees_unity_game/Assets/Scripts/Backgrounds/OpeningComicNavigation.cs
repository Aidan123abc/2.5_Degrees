using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningComicNavigation : MonoBehaviour
{
    public string nextScene = "Level1";
    public GameObject[] panels;
    private int panelsLength;
    private int currentPanel = 0;
    private Vector3 newPos;
    private float camSpeed = 4f;
    private float panelChangeDelay = 5f; // Default delay between panel changes
    private float timer = 0f;

    void Start()
    {
        panelsLength = panels.Length;
        // Initialize camera position and newPos to the first panel's position
        Vector3 initialPos = panels[0].transform.position;
        transform.position = new Vector3(initialPos.x, initialPos.y, transform.position.z);
        newPos = initialPos;
        Debug.Log("Starting at Panel 0: Position - " + newPos);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= panelChangeDelay)
        {
            timer = 0f;
            NextPanel();
        }
    }

    void FixedUpdate()
    {
        Vector3 pos = Vector3.Lerp(transform.position, newPos, camSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        Debug.Log("Camera moving to: " + newPos);
    }

    void NextPanel()
    {
        if (currentPanel < panelsLength - 1)
        {
            currentPanel++;
            newPos = panels[currentPanel].transform.position;
            Debug.Log("Moving to Panel " + currentPanel + ": Position - " + newPos);
            
            // Change panelChangeDelay based on panel number
            if (currentPanel == 6) // Assuming the 7th panel is index 6 (0-based index)
            {
                panelChangeDelay = 10f; // Set delay for 7th panel
            }
            else
            {
                panelChangeDelay = 5f; // Reset delay for other panels
            }
        }
        else
        {
            Debug.Log("Loading next scene.");
            SceneManager.LoadScene(nextScene);
        }
    }
}
