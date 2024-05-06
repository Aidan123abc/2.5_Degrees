using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHandler : MonoBehaviour
{
    private GameObject player; 
    public static int playerHealth = 90;
    //public int StartPlayerHealth = 100;
    //public int startTemp = 75;
    public GameObject healthText;
    public bool tempIncrease;

    public static int acorns = 0; 
    public GameObject acornsText; 
    public GameObject tempText;
    public static int temp = 50; 
    public float tempForSlider;
    public tempSlider myTempSlider;
    public tempSlider myHealthSlider;

    public GameObject objectToSpawn;
    public Vector2 origin = Vector2.zero;
    public float radius = 10;

    public string noAcornsText = "You have no acorns! Collect more!";
    public string NotEnoughText = "You need 3 acorns to plant!";
    public string fullHealthText = "You are already at full health!";
    public GameObject PopUpTextPrefab;


    private Transform playerTransform;
    private GameObject Squirrel;
    private SquirrelController squirrelScript;


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
                  //playerHealth = StartPlayerHealth;
                  // temp = startTemp;
                  tempForSlider = temp/100f;
                  // Debug.Log("Temperature at: " + temp);
                  // Debug.Log("Slider at: " + tempForSlider);
            //}
            updateStatsDisplay();
            if (myTempSlider != null) {
                    myTempSlider.setProgress(tempForSlider); // Adjust the argument as needed
            }

            if (myHealthSlider != null) {
                    myHealthSlider.setProgress(playerHealth/100f); // Adjust the argument as needed
            }

            Text tokensTextTemp = acornsText.GetComponent<Text>();
            Text tempTextDisplay = tempText.GetComponent<Text>();
            tokensTextTemp.text = "#" + acorns;
            tempTextDisplay.text = "Temperature: " + temp;

            squirrelScript = Squirrel.GetComponent<SquirrelController>(); // Assign the component
            if (squirrelScript == null)
            {
                Debug.LogError("SquirrelController script not found on the Squirrel GameObject.");
            }

            if (tempIncrease == true) {
                  InvokeRepeating("increaseTemperature", 10.0f, 10.0f);
            }
    }
      

        void Update () {
            

            if (Input.GetKeyDown(KeyCode.E)){
                  playerEat();
                  squirrelScript.SquirrelEat();
            }
            if (Input.GetKeyDown(KeyCode.Q)){
                  playerPlant();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
        // Do not perform any action related to the temperature slider here
        // This block ensures that the left and right arrow keys do not affect the slider
    }
      }

      public void playerEat() {
             if ((acorns > 0) && (playerHealth < 100)) {
                  acorns = acorns - 1;
                  playerHealth += 2;
                  updateStatsDisplay();
                  updateHealthSlider(0.02f);
                  } else if (acorns < 1) {
                        showFloatingText(noAcornsText);
                        } 
                  else if (playerHealth > 99) {showFloatingText(fullHealthText);}

                  
      }

      public void playerPlant() {
            if (acorns > 2) {
                  acorns = acorns - 3;
                  temp = temp - 5;
                  Vector2 treeSpawnLocation;
                  treeSpawnLocation = new Vector2((playerTransform.position.x + 0.00f), playerTransform.position.y);
                  GameObject Tree = Instantiate(objectToSpawn, treeSpawnLocation, Quaternion.identity);
                  // TreeGrowthAnim treeScript = Tree.GetComponent<TreeGrowthAnim>();
                  updateStatsDisplay();
                  updateTemperatureSlider(-0.05f);

                  } else {showFloatingText(NotEnoughText);}
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
                        updateHealthSlider(-0.03f);
                        squirrelScript.TriggerHurtAnimation();
                  } 
                  if (damage > 0){ 
                        // player.GetComponent<PlayerHurt>().playerHit();       //play GetHit animation 
                  } 
            } 

      //      if (playerHealth > StartPlayerHealth){
      //             playerHealth = StartPlayerHealth; 
      //             updateStatsDisplay();
      //       }

           if (playerHealth <= 0){
                  playerHealth = 0; 
                  Debug.Log("Die?");
                  squirrelScript.SquirrelDies();
                  updateStatsDisplay();
                  // Application.Quit();       //Update later! change so does not quit
            }
      }

      public void playerPickUp(int amount) {
            acorns = acorns + amount;

            Text tokensTextTemp = acornsText.GetComponent<Text>();
            tokensTextTemp.text = "#" + acorns;
      }

      public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "HEALTH: " + playerHealth; 

            Text tokensTextTemp = acornsText.GetComponent<Text>();
            tokensTextTemp.text = "#" + acorns;

            Text tempTextDisplay = tempText.GetComponent<Text>();
            tempTextDisplay.text = "Temperature: " + temp;

           
  
      }

      public void updateTemperatureSlider(float amount) {
             //updates slider bar
            if (myTempSlider != null) {
                    myTempSlider.IncrementProgress(amount); // Adjust the argument as needed
            }
      }

      public void updateHealthSlider(float amount) {
            //updates slider bar
            Debug.Log("Hello?");
            if (myHealthSlider != null) {
                    myHealthSlider.IncrementProgress(amount); // Adjust the argument as needed
            }
      }
      
      public int getAcornCount() {
            return acorns;
      }

      public void increaseTemperature() {
            temp += 1;
            updateStatsDisplay();
            updateTemperatureSlider(0.01f);
      }
      
      public void showFloatingText(string message) {
            Debug.Log("CalledFloating");
            // Instantiate the popup text prefab at the player's position and keep a reference to the instantiated object
            Vector2 playerPosition = playerTransform.position * 1.0f;
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

      // public void SquirrelHurtAnimation() {
      //   // Ensure the Squirrel GameObject is assigned in the inspector.
      //   if (Squirrel != null)
      //   {
      //       squirrelScript.TriggerHurtAnimation();
      //   }
            // Get the SquirrelController script component from the Squirrel GameObject.
      // }

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

