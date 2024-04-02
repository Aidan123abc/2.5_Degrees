using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    private GameObject player; 
    public int playerHealth = 100;
    public int StartPlayerHealth = 100;
    public GameObject healthText;

    public static int acorns = 0; 
    public GameObject acornsText; 

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
            //}
            updateStatsDisplay();
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

      public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "HEALTH: " + playerHealth; 

            //updates slider bar
            tempSlider mySlider = FindObjectOfType<tempSlider>();
            if (mySlider != null) {
                    mySlider.IncrementProgress(-0.05f); // Adjust the argument as needed
            }

            Text tokensTextTemp = acornsText.GetComponent<Text>();
            tokensTextTemp.text = "ACORNS: " + acorns;
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

