using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collission : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public ParticleSystem flameParticle;
    private PlayerController playerControllerScript;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        explosionParticle.Stop();
        flameParticle.Play();
    }

    void OnCollisionEnter(Collision other) {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Ground")){
            Debug.Log("hit Ground");
            explosionParticle.Play();
            StartCoroutine(DestroyDelayed());
            // Destroy(gameObject, 10);
        } else if(other.gameObject.CompareTag("Player")) {
            Debug.Log("hit Player");
            GameOver();
        } else {
            Debug.Log(other.gameObject);
            Debug.Log("Who did i activate?");
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Who activated Me?");
    }

    void GameOver()
    {
        explosionParticle.Play();
        playerControllerScript.playerAudio.Stop();
        playerControllerScript.playerAudio.clip = playerControllerScript.crashSound;
        playerControllerScript.playerAudio.volume = 0.9f;
        playerControllerScript.playerAudio.Play();
        gameManager.gameOver = true;
    }

    IEnumerator DestroyDelayed()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
