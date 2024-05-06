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
    private float panelChangeDelay = 3f; // Adjust as needed for the delay between panel changes
    private float timer = 0f;

    void Start()
    {
        panelsLength = panels.Length;
        Vector3 initialPos = panels[0].transform.position;
        transform.position = new Vector3(initialPos.x, initialPos.y, transform.position.z);
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
        Vector2 pos = Vector2.Lerp((Vector2)transform.position, (Vector2)newPos, camSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }

    void NextPanel()
    {
        if (currentPanel < (panelsLength - 1))
        {
            currentPanel++;
            newPos = panels[currentPanel].transform.position;
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}