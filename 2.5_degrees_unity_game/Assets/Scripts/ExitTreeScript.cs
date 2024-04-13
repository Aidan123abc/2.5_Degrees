using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTreeScript : MonoBehaviour
{
    public Sprite image1;
    public Sprite image2;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Optionally set the initial sprite
        spriteRenderer.sprite = image1;
    }
    
    public void OpenTreeDoor() {
        spriteRenderer.sprite = image1;
    }

    public void CloseTreeDoor() {
        spriteRenderer.sprite = image2;
    }
}
