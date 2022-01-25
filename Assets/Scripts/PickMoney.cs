using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMoney : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(DestroyDelayed());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
            Destroy(gameObject);
            turnOnEngine();
        }
    }

    void Pickup(){
        Debug.Log("Money Was Picked");
        playerControllerScript.playerAudio.PlayOneShot(playerControllerScript.pickupSound, 1.0f);
        gameManager.AddScore(10);
        Debug.Log(playerControllerScript.score);
    }

    void turnOnEngine()
    {
        playerControllerScript.playerAudio.clip = playerControllerScript.driveSound;
        playerControllerScript.playerAudio.volume = 0.9f;
        playerControllerScript.playerAudio.Play();
    }

    IEnumerator DestroyDelayed()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
