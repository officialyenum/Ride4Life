using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public float score = 0;
    public float timeCounter = 100;
    static public Text playerName;
    public Text playerScore;
    public Text timer;

    public void Awake() {
        playerName = GameObject.Find("playerName").GetComponent<Text>();
        playerName.text = StartGame.startGame.playerName;
        playerScore = GameObject.Find("playerScore").GetComponent<Text>();
        timer = GameObject.Find("timer").GetComponent<Text>();
        NoDestroyMethod();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void GoToTitle () {
        Debug.Log ("You Clicked Title Button");
        SceneManager.LoadScene("Title");
        
    }

}
