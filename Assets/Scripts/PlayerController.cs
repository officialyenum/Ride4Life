using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 45.0f;
    private float turnSpeed = 30.0f;
    private float horizontalInput;
    private float forwardInput;
    public AudioSource playerAudio;
    public AudioClip driveSound;
    public AudioClip crashSound;
    public AudioClip pickupSound;
    public Text playerName;
    public Text playerScore;
    public Text timerLeft;
    // public float score = 0;
    private GameManager gameManager;
    private Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerName.text = gameManager.username.ToString();
        playerScore.text = "" + gameManager.score;
        rb = GetComponent<Rigidbody>();
        timerLeft.text = "00:" + gameManager.timeCounter;
        Debug.Log(gameManager.gameOver);
    }

    void Update(){
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.gameOver == false || gameManager.gamePaused == false)
        {
            // move vehicle forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            // turn vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerAudio.clip = driveSound;
            playerAudio.volume = 0.9f;
            playerAudio.Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            StartCoroutine(FadeAudioSource.StartFade(playerAudio, 0.005f, 0.2f));
        }

        if (gameManager.takingAway == false && gameManager.timeCounter > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    public void AddScore(float value)
    {
        gameManager.score += value;
        playerScore.text = "" + gameManager.score;
    }

    IEnumerator TimerTake()
    {
        gameManager.takingAway = true;
        yield return new WaitForSeconds(1);
        gameManager.timeCounter -= 1;
        if (gameManager.timeCounter < 10)
        {
            timerLeft.text = "00:0" + gameManager.timeCounter;
        }else{
            timerLeft.text = "00:" + gameManager.timeCounter;
        }
        gameManager.takingAway = false;
    }

    
}
