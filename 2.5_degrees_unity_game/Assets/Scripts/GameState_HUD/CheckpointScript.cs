using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject flagDown;
    public GameObject flagUp;
    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initially, show Flag_down and hide Flag_up
        flagDown.SetActive(true);
        flagUp.SetActive(false);
    }

    // Public function to activate the checkpoint and change the flag visibility
    public void ActivateCheckpoint()
    {
        if (!activated)
        {
            flagDown.SetActive(false);
            flagUp.SetActive(true);
            activated = true;
        }
    }

    // Detect collisions with other GameObjects
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is tagged as "Player" (or another relevant tag)
        if (other.CompareTag("Player"))
        {
            ActivateCheckpoint();
        }
    }
}
