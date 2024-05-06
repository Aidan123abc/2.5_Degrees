using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Treehouse : MonoBehaviour
{
    [SerializeField] private GameObject treehouseText;
    public PauseMenuHandler menuHandler;  // Changed type to PauseMenuHandler

    void Start()
    {
        if (treehouseText != null)
            treehouseText.SetActive(false);
        else
            Debug.LogError("Treehouse Text GameObject is not assigned!");
    }

    public void Enter_Treehouse()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        treehouseText.SetActive(true);

        if (sceneName == "Tutorial") {
            StartCoroutine(HideTextAfterTime(5));
            Debug.Log("Open Backstory Scene");
        } else {
            StartCoroutine(HideTextAfterTime(5));
            menuHandler.OpenMap();
        }
    }

    IEnumerator HideTextAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        treehouseText.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 leftShift = new Vector3(-1.0f, 0, 0); // Change this value to adjust how far you want to move the object.
            collision.transform.position += leftShift;
            Enter_Treehouse();
        }
    }
}
