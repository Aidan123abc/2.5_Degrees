
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
        public AudioMixer mixer;
        public static float volumeLevel = 1.0f;
        private Slider sliderVolumeCtrl;
        public GameObject map;
        public Button City2Button;
        public Button Beach1Button;
        public Button TundraButton;
        public Button NorthPoleButton;

        void Awake (){
                SetLevel (volumeLevel);
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
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

                if (GameHandler.temp > 36) {
                        NorthPoleButton.interactable = false;
                } else {
                        NorthPoleButton.interactable = true;
                }
                if (GameHandler.temp > 41) {
                        TundraButton.interactable = false;
                } else {
                        TundraButton.interactable = true;
                } if (GameHandler.temp > 46) {
                        Beach1Button.interactable = false;
                } else {
                        Beach1Button.interactable = true;
                } if (GameHandler.temp > 56) {
                        City2Button.interactable = false;
                } else {
                        City2Button.interactable = true;
                }

        }

        public void OpenMap(){
                MapUI.SetActive(true);
                //YouAreHereMap squirrel = map.GetComponent<YouAreHereMap>();
                Time.timeScale = 0f;
                GameisPaused = true;
                //squirrel.getLocation();
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

        public void Tundra2(){
                Time.timeScale = 1f;
                GameisPaused = false;
                SceneManager.LoadScene("Winter_Level2");
                
        }

        public void City(){
                Time.timeScale = 1f;
                GameisPaused = false;
                SceneManager.LoadScene("City");
        }

        public void City2(){
                    Time.timeScale = 1f;
                    GameisPaused = false;
                    SceneManager.LoadScene("City2");
        }

        public void Beach(){
                Time.timeScale = 1f;
                GameisPaused = false;
                SceneManager.LoadScene("Beach2");
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
                mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                volumeLevel = sliderValue;
        }
}
