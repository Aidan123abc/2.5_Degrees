using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public static int temp; 

    public GameObject objectToSpawn;
    public Vector2 origin = Vector2.zero;
    public float radius = 10;

    public string noAcornsText = "You have no acorns! Collect more!";
    public string fullHealthText = "You are already at full health!";
    public GameObject PopUpTextPrefab;


    private Transform playerTransform;
    private GameObject Squirrel;


      public bool isDefending = false; 

      public static bool stairCaseUnlocked = false; 
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true; 

      private string sceneName; 
      public static string lastLevelDied;  //allows replaying the Level where you died

      void Start(){
            Squirrel = GameObject.FindWithTag("Player");
            if (Squirrel != null) {
                  playerTransform = Squirrel.transform;
            }
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
                  if ((acorns > 0) && (playerHealth < 100)) {
                  acorns -= acorns;
                  playerHealth += 3;
                  updateStatsDisplay();
                  } else if (acorns < 1) {
                        showFloatingText(noAcornsText);
                        } 
                  else if (playerHealth > 99) {showFloatingText(fullHealthText);}
            }
            if (Input.GetKeyDown(KeyCode.Q)){
                  if (acorns > 0) {
                  acorns -= acorns;
                  temp = temp - 1;
                  //Vector2 randomPosition = origin + Random.insideUnitSphere * radius;
                  Vector2 playerPosition = playerTransform.position * 1.1f;
                  Instantiate(objectToSpawn, playerPosition, Quaternion.identity);
                  updateStatsDisplay();
                  } else {Debug.Log("There are no acorns to eat! Collect more!");}
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
                        SquirrelHurtAnimation();
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

      public void updateTemperature(int amount) {

      } 
      
      public void showFloatingText(string message) {
            Debug.Log("CalledFloating");
            // Instantiate the popup text prefab at the player's position and keep a reference to the instantiated object
            Vector2 playerPosition = playerTransform.position * 1.1f;
            GameObject instantiatedPopUpText = Instantiate(PopUpTextPrefab, playerPosition, Quaternion.identity);
            

            // Now, access the TextMeshProUGUI component on the instantiated object
            TMPro.TextMeshPro textMesh = instantiatedPopUpText.GetComponent<TMPro.TextMeshPro>();
            textMesh.SetText(message);
            // if (textMesh != null) {
            //       textMesh.text = "TEST STRING"; // Now you are setting the text on the instantiated object
            // } else {
            //       Debug.LogError("TextMeshProUGUI component not found on the instantiated PopUpTextPrefab.");
            // }
      }

      public void SquirrelHurtAnimation() {
        // Ensure the Squirrel GameObject is assigned in the inspector.
        if (Squirrel != null)
        {
            // Get the SquirrelController script component from the Squirrel GameObject.
            SquirrelController squirrelScript = Squirrel.GetComponent<SquirrelController>();

            // Ensure the SquirrelController script was found.
            if (squirrelScript != null)
            {
                // Trigger the hurt animation.
                squirrelScript.TriggerHurtAnimation();
            }
            else
            {
                Debug.LogError("SquirrelController script not found on the Squirrel GameObject.");
            }
        }
        else
        {
            Debug.LogError("Squirrel GameObject is not assigned in the GameHandler script.");
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

