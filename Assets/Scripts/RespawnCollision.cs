using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCollision : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision other) {
        Debug.Log(other);
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("hit Player");
            GameOver();
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Who activated Respawn?");
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("hit Player");
            GameOver();
        }
    }

    void GameOver()
    {
        playerControllerScript.playerAudio.Stop();
        playerControllerScript.playerAudio.clip = playerControllerScript.crashSound;
        playerControllerScript.playerAudio.volume = 0.9f;
        playerControllerScript.playerAudio.Play();
        gameManager.gameOver = true;
    }
}
