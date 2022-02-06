using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Text username;
    public Text time;
    public Text dollar;
    public Button homeButton;
    private GameManager gameManager;
    private void Awake() 
    {
        homeButton.onClick.AddListener(GoToTitle);
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        username.text = "Username : "+ gameManager.username;
        time.text = "Time Left :"+gameManager.timeCounter + " secs";
        dollar.text = "Amount : "+gameManager.score + " dollars";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToTitle () {
        Destroy(gameManager);
        SceneManager.LoadScene("Title");
    }

    public void Connect() 
    {
        string time = gameManager.timeCounter.ToString();
        string score = gameManager.score.ToString();
        string tweet = "Hello%20%40officialyenum%20i%20just%20played%20%23ride4life%20and%20i%20scored%20"+score+"%20with%20"+time+"%20secs%20left%2C%20nice%20game%20lad";
        string url = "https://twitter.com/intent/tweet?text=" + tweet;
        Debug.Log(url);
        Application.OpenURL(url);
    }
}
