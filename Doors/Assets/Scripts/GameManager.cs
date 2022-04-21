using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public  GameObject Player, Chest, Door;
    Vector3 spawnPos;
    public TextMeshProUGUI timeText;
     [SerializeField] private GameObject titleScreen;
     [SerializeField] private Button restartButton; 
    [SerializeField] private GameObject gameOverScreen;
     [SerializeField] private Button startButton;
   [SerializeField] private GameObject chestScreen;
     [SerializeField] private GameObject keyPanel;
   [SerializeField] private bool ChestIsOpen;
   public int hightScore = 1;
    [SerializeField] private Text hightScoreText;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text findText;
    private bool m_GameOver = false;
    private bool haveKey;
    private int timer;
    private float spawnRange = 5.0f;
    [SerializeField] private bool isGameActive;
    public int currentScore;

    private float startTime;

   
[System.Serializable]
    class SaveData
    {
        public int hightScore;
        
    }

// save data json
public void SaveInput()
{
    SaveData data = new SaveData();
    data.hightScore = hightScore;
    string json = JsonUtility.ToJson(data);
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}
// load data json
public void LoadInput()
{
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        hightScore = data.hightScore;
    }
}

    void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(m_GameOver)
        return;
        if(isGameActive)
        {
            CounterTime();
        }

    }
    public void StartGame()
    {   
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        startTime = Time.time;
        Instantiate(Player, spawnPos, Quaternion.identity);
        Instantiate(Chest, GenerateSpawnPosition(), Quaternion.identity);
        Instantiate(Door, GenerateSpawnPosition(), Quaternion.identity);
        haveKey = false;
        ChestIsOpen = false;
        findText.gameObject.SetActive(false);
    }


     //Generating random spawn position
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomSpown = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomSpown;
    }
//Counter time when game is started
     private void CounterTime()
    {
        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        
        timeText.text = minutes + ":" + seconds;


    }



    // Stop game, bring up game over text and restart button
    public void GameOver()
    {  
        if(haveKey)
        { 
            timeText.color = Color.red;
            currentScoreText.text = "Current Score: " + timeText.text;
        isGameActive = false;
         m_GameOver = true;
          SaveInput();

          
         if(isGameActive = false)    
            {    
           LoadInput();
            hightScoreText.text = "Hight Score: " + currentScore;
            }
        gameOverScreen.gameObject.SetActive(true);
        }
    }
    public void FindKey()
    {

            //Place for text on the screen  "Find a Key"
            Debug.Log("Find a key");
            findText.gameObject.SetActive(true);
    
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Method for Chest script
    public void chestScreenRun()
    {
            chestScreen.gameObject.SetActive(true);  
;

    }

    //Method for Button Yes in ChestScreen
    public void OpenChest()
    {
         chestScreen.gameObject.SetActive(false);
         // place for animator chestOpening

         ChestIsOpen = true;

    }
    
    //Method for Key script
    public void KeyClicked()
    {
        if(ChestIsOpen = true)
        {
            keyPanel.gameObject.SetActive(true);
            findText.gameObject.SetActive(false);
        }
    }
    //Method for Button Yes in keyPanel screen. 
    public void TakeKey()
    {
       keyPanel.gameObject.SetActive(false);
       haveKey = true;
       //animation Key
    }
    //Method for both No Button 
    public void NoButton()
    {
        chestScreen.gameObject.SetActive(false);

        keyPanel.gameObject.SetActive(false);

    }

}


