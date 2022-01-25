using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public float score = 0;
    public float timeCounter = 0;
    public Text playerName;
    public Text playerScore;
    public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        playerName = GameObject.Find("playerName").GetComponent<Text>();
        playerScore = GameObject.Find("playerScore").GetComponent<Text>();
        timer = GameObject.Find("timer").GetComponent<Text>();

        NoDestroyMethod();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NoDestroyMethod()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

    public void AddScore(float value)
    {
        score += value;
        playerScore.text = "Score : " + score.ToString();
    }

    public void AddTime(float value)
    {
        timeCounter += value;
        timer.text = timeCounter.ToString();
    }
}
