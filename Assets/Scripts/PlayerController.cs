using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool gameOver = false;
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if(gameOver == false) {
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

    
}
