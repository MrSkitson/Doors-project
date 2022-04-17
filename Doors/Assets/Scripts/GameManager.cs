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

    public  GameObject Player, Chest;
    Vector3 spawnPos;
    public TextMeshProUGUI timeText;
     public GameObject titleScreen;
     public Button restartButton; 
     public GameObject gameOverScreen;
     public Button startButton;
    public GameObject chestScreen;
     public GameObject keyPanel;
    public bool ChestIsOpen;
    public int hightScore = 10;
    public Text hightScoreText;
    private bool m_GameOver;
    private bool isDourOpen;
    private bool haveKey;
    private int timer;
    private float spawnRange = 4.0f;
    public bool isGameActive;
   
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

   
    
    }
    // Start is called before the first frame update
    void Start()
    {
       Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        while (isDourOpen)
        {
            m_GameOver = true;
        }
        if(m_GameOver = true)
        {
            
            if(timer > hightScore)    
            {
            hightScore = timer;
            SaveInput();

           }
           
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    public void StartGame()
    {   
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        InvokeRepeating("CounterTime", 0, 1);
        Instantiate(Player, spawnPos, Quaternion.identity);
        Instantiate(Chest, GenerateSpawnPosition(), Quaternion.identity);
        m_GameOver = false;
        haveKey = false;
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
        if (isGameActive = true)
        {
            timer ++;
            timeText.text = "Time: " + timer;
        }
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
     if(m_GameOver = true)
        {gameOverScreen.gameObject.SetActive(true);
            isGameActive = false; 
        }
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void chestScreenRun()
    {
 
            chestScreen.gameObject.SetActive(true);

    }
    public void OpenChest()
    {
         chestScreen.gameObject.SetActive(false);
         keyPanel.gameObject.SetActive(true);
    }
    public void TakeKey()
    {
       keyPanel.gameObject.SetActive(false);
       haveKey = true;
    }

    public void NoButton()
    {
        chestScreen.gameObject.SetActive(false);

        keyPanel.gameObject.SetActive(false);

    }

}

