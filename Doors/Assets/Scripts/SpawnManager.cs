using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public  GameObject Player;
    public GameObject Chest;
    Vector3 spawnPos;

    void Awake()
    {
        Instantiate(Player, spawnPos, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}

