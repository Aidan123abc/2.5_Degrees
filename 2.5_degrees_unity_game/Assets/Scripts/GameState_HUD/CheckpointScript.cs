using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the initial color to white
        spriteRenderer.color = Color.white;
    }

    // Public function to activate the checkpoint and change its color to green
    public void ActivateCheckpoint()
    {
        if (!activated)
        {
            spriteRenderer.color = Color.green;
            activated = true;
        }
    }
}
