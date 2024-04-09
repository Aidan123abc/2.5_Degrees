using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

      public void StartGame() {
            SceneManager.LoadScene("City");
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }

      public void Home() {
        SceneManager.LoadScene("Title_Page");
      }

      public void LoadWinter() {
            SceneManager.LoadScene("Winter_Level");
      }
}
