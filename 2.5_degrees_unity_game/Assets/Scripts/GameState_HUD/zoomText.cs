using UnityEngine;
using TMPro;
using System.Collections;

public class ZoomInText : MonoBehaviour
{
    private TextMeshPro textMesh; // Using TextMeshPro for non-UI text elements
    public float zoomDuration = 1.0f; // Duration of the zoom effect
    public Vector3 targetScale = new Vector3(1, 1, 1); // Target scale to zoom in

    void Start()
    {
        // Attempt to get the TextMeshPro component attached to the same GameObject
        textMesh = GetComponent<TextMeshPro>();
        if (textMesh == null)
        {
            Debug.LogError("TextMeshPro component not found on the GameObject.");
            return; // Exit if no TextMeshPro component found
        }

        // Start the zoom effect after a delay
        StartCoroutine(ZoomInEffect());
    }

    IEnumerator ZoomInEffect()
    {
        // Wait for 10 seconds before starting the tween
        yield return new WaitForSeconds(30);

        float currentTime = 0;
        Vector3 originalScale = textMesh.transform.localScale;

        while (currentTime < zoomDuration)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / zoomDuration;
            t = t*t * (3f - 2f*t); // Smooth step interpolation formula for smoothness

            textMesh.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        textMesh.transform.localScale = targetScale;
    }
}
