
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class PauseMenuHandler : MonoBehaviour
{
     public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public GameObject MapUI;
        // public AudioMixer mixer;
        // public static float volumeLevel = 1.0f;
        //private Slider sliderVolumeCtrl;

        void Awake (){
                // SetLevel (volumeLevel);
                // GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                // if (sliderTemp != null){
                //         sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                //         sliderVolumeCtrl.value = volumeLevel;
                // }
        }

        void Start (){
                pauseMenuUI.SetActive(false);
                MapUI.SetActive(false);
                GameisPaused = false;
        }

        void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
        }

        public void OpenMap(){
                MapUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
        }

        public void Forest(){
                Time.timeScale = 1f;
                GameisPaused = false;
                SceneManager.LoadScene("Tutorial");
        }

        public void Tundra(){
                Time.timeScale = 1f;
                GameisPaused = false;
                SceneManager.LoadScene("Winter_Level");
        }

        public void City(){
                Time.timeScale = 1f;
                GameisPaused = false;
                SceneManager.LoadScene("City");
        }

        public void Pause(){
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void CloseMap(){
                MapUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void SetLevel (float sliderValue){
                // mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                // volumeLevel = sliderValue;
        }
}
