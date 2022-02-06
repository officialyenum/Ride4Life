using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float startDelay = 2;
    private float repeatRate = 1.5f;
    private GameManager gameManager;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {

        //Invoke Repeating a function by setting start delay and repeat  rate 
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
        //instantiate a game Object Script file
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles () 
    {
        Vector3 startPos = playerController.transform.position;

        //if game Over in Player Controller script is false spawn Obstacle else do nothing
        if (gameManager.gameOver == false)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            
            Vector3 spawnPos = new Vector3(Random.Range(150, 800), 200f,  Random.Range(150, 850));
            //instantiate a prefab, assign position and set its rotation
            Instantiate(obstaclePrefabs[index], spawnPos, obstaclePrefabs[index].transform.rotation);
            
        }
    }
}
