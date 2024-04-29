using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YouAreHereMap : MonoBehaviour
{
    public RectTransform playerInMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getLocation() {
        string sceneName = SceneManager.GetActiveScene().name;
        playerInMap = GameObject.FindWithTag("Map").GetComponent<RectTransform>();
        if (sceneName == "City") {
            playerInMap.localPosition = new Vector3(30f, 30f, 0f);
        } else if (sceneName == "Winter_Level") {
            playerInMap.localPosition = new Vector3(30f, 300f, 0f);
        } else if (sceneName == "Beach2") {
            playerInMap.localPosition = new Vector3(-300f, 30f, 0f);
        } else {
            playerInMap.localPosition = new Vector3(-300f, 300f, 0f);
        }
    }
}
