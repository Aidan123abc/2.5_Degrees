using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    private GameObject player; 
    public int playerHealth = 100;
    public int StartPlayerHealth = 100;
    public int startTemp = 100;
    public GameObject healthText;

    public static int acorns = 0; 
    public GameObject acornsText; 
    public GameObject tempText;
    public int temp; 

public bool isDefending = false; 

      public static bool stairCaseUnlocked = false; 
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true; 

      private string sceneName; 
      public static string lastLevelDied;  //allows replaying the Level where you died

      void Start(){
            player = GameObject.FindWithTag("Player");
            // sceneName = SceneManager.GetActiveScene().name;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  playerHealth = StartPlayerHealth;
                  temp = startTemp;
            //}
            updateStatsDisplay();
            Text tokensTextTemp = acornsText.GetComponent<Text>();
            Text tempTextDisplay = tempText.GetComponent<Text>();
            tokensTextTemp.text = "ACORNS: " + acorns;
            tempTextDisplay.text = "Temperature: " + temp + " Degrees";
      }

        void Update () {
            if (Input.GetKeyDown(KeyCode.E)){
                  acorns -= acorns;
                  playerHealth += 5;
                  updateStatsDisplay();
            }
            if (Input.GetKeyDown(KeyCode.Q)){
                  acorns -= acorns;
                  temp = temp - 1;
                  updateStatsDisplay();
            }
      }

      public void playerGetTokens(int newTokens){
            acorns += acorns;
            updateStatsDisplay();
      }

      public void playerGetHit(int damage){
           if (isDefending == false){
                  playerHealth -= damage; 
                  if (playerHealth >=0){ 
                        updateStatsDisplay(); 
                  } 
                  if (damage > 0){ 
                        // player.GetComponent<PlayerHurt>().playerHit();       //play GetHit animation 
                  } 
            } 

           if (playerHealth > StartPlayerHealth){
                  playerHealth = StartPlayerHealth; 
                  updateStatsDisplay();
            }

           if (playerHealth <= 0){
                  playerHealth = 0; 
                  updateStatsDisplay();
                  Application.Quit();       //Update later! change so does not quit
            }
      } 

      public void playerPickUp(int amount) {
            acorns = acorns + amount;

            Text tokensTextTemp = acornsText.GetComponent<Text>();
            tokensTextTemp.text = "ACORNS: " + acorns;
      }

      public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "HEALTH: " + playerHealth; 

            Text tokensTextTemp = acornsText.GetComponent<Text>();
            tokensTextTemp.text = "ACORNS: " + acorns;

            Text tempTextDisplay = tempText.GetComponent<Text>();
            tempTextDisplay.text = "Temperature: " + temp + " Degrees";

            //updates slider bar
            tempSlider mySlider = FindObjectOfType<tempSlider>();
            if (mySlider != null) {
                    mySlider.IncrementProgress(-0.5f); // Adjust the argument as needed
            }
  
      } 
      

    //   public void playerDies(){
    //         player.GetComponent<PlayerHurt>().playerDead();       //play Death animation 
    //         lastLevelDied = sceneName;       //allows replaying the Level where you died 
    //         StartCoroutine(DeathPause());
    //   }

    //   IEnumerator DeathPause(){
    //         player.GetComponent<PlayerMove>().isAlive = false;
    //         player.GetComponent<PlayerJump>().isAlive = false;
    //         yield return new WaitForSeconds(1.0f);
    //         SceneManager.LoadScene("EndLose");
    //   }

//       public void StartGame() {
//             SceneManager.LoadScene("Level1");
//       }

//       // Return to MainMenu
//       public void RestartGame() { 
//             Time.timeScale = 1f; 
//             SceneManager.LoadScene("MainMenu");
//              // Reset all static variables here, for new games:
//             playerHealth = StartPlayerHealth;
//       }

//       // Replay the Level where you died
//       public void ReplayLastLevel() { 
//             Time.timeScale = 1f;
//             SceneManager.LoadScene(lastLevelDied); 
//              // Reset all static variables here, for new games:
//             playerHealth = StartPlayerHealth;
//       }

//       public void QuitGame() {
//                 #if UNITY_EDITOR 
//                 UnityEditor.EditorApplication.isPlaying = false; 
//                 #else 
//                 Application.Quit(); 
//                 #endif
//       }

//       public void Credits() {
//             SceneManager.LoadScene("Credits");
//       }
}

