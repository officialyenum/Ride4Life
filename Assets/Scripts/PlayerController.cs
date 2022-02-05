using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 30.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    public AudioSource playerAudio;
    public AudioClip driveSound;
    public AudioClip crashSound;
    public AudioClip pickupSound;
    public Text playerName;
    public Text playerScore;
    public Text timerLeft;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerName.text = gameManager.username;
        playerScore.text = "" + gameManager.score;
        timerLeft.text = "00:" + gameManager.timeCounter;
        Debug.Log(gameManager.gameOver);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if (gameManager.gameOver == false)
        {
            // move vehicle forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            // turn vehicle
            // float yRotation = transform.eulerAngles.y;
            //  transform.eulerAngles = new Vector3( transform.eulerAngles.x, yRotation, transform.eulerAngles.z );
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerAudio.clip = driveSound;
            playerAudio.volume = 0.9f;
            playerAudio.Play();
            Debug.Log("W key was pressed");
            // playerAudio.PlayOneShot(driveSound, 1.0f);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("W key was released");
            StartCoroutine(FadeAudioSource.StartFade(playerAudio, 0.005f, 0.2f));
        }
    }


    public void AddScore(float value)
    {
        gameManager.score += value;
        playerScore.text = "" + gameManager.score;
    }

    

    
}
