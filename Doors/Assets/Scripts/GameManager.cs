using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  GameObject Player, Chest;
    Vector3 spawnPos;
    public TextMeshProUGUI timeText;
     public GameObject titleScreen;
     public Button restartButton; 
     public GameObject gameOverScreen;
     public Button startButton;


    private int timer = 0;
    private float spawnRange = 4.0f;
    public bool isGameActive;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
        InvokeRepeating("CountTimer", 0, 1);
        Instantiate(Player, spawnPos, Quaternion.identity);
        Instantiate(Chest, GenerateSpawnPosition(), Quaternion.identity);
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
     private void CountTimer()
    {
        if (isGameActive = true)
        {
            timer ++;
            timeText.text = "Time: " + timer;
        }
        if(isGameActive = false)
        {
            GameOver();
        }
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        
        gameOverScreen.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
       isGameActive = false; 
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
