using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollission : MonoBehaviour
{
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")) {
            Debug.Log("Money hit Player");
            playerControllerScript.playerAudio.Stop();
            playerControllerScript.playerAudio.clip = playerControllerScript.pickupSound;
            playerControllerScript.playerAudio.volume = 0.9f;
            playerControllerScript.playerAudio.Play();
            playerControllerScript.score += 1;
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Who activated Me?");
    }
}
