using UnityEngine;
using TMPro;
using System.Collections;

public class ZoomInText : MonoBehaviour
{
    private TextMeshProUGUI textMesh; // Now private, will be set in Start()
    public float zoomDuration = 1.0f; // Duration of the zoom effect
    public Vector3 targetScale = new Vector3(2, 2, 2); // Target scale to zoom in

    void Start()
    {
        // Attempt to get the TextMeshProUGUI component attached to the same GameObject
        textMesh = GetComponent<TextMeshProUGUI>();
        if (textMesh == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the GameObject.");
            return; // Exit if no TextMeshProUGUI component found
        }

        // Start the zoom effect
        StartCoroutine(ZoomInEffect());
    }

    IEnumerator ZoomInEffect()
    {
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
