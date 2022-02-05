using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTime : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.takingAway == false && gameManager.timeCounter > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    IEnumerator TimerTake()
    {
        gameManager.takingAway = true;
        Debug.Log(gameManager.timeCounter);
        yield return new WaitForSeconds(1);
        gameManager.timeCounter -= 1;
        if (gameManager.timeCounter < 10)
        {
            playerControllerScript.timerLeft.text = "00:0" + gameManager.timeCounter;
        }else{
            playerControllerScript.timerLeft.text = "00:" + gameManager.timeCounter;
        }
        gameManager.takingAway = false;
    }
}
