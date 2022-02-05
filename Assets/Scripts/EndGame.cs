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
    private GameManager gameManager;
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
        Debug.Log ("You Clicked Title Button");
        SceneManager.LoadScene("Title");
    }

    public void Connect() 
    {
        Debug.Log("You Clicked Connect");
    }
}
