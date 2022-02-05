using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    public Button startButton;
    public InputField nameInput;
    public string playerName;
    public string errorMessage;
    public Text errorMessageText;
    private GameManager gameManager;

    private void Awake() 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        errorMessageText = GameObject.Find("error").GetComponent<Text>();
        startButton.onClick.AddListener(GoToGame);
        nameInput.onValueChanged.AddListener(delegate {readPlayerInput(); });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {

    }

    public void readPlayerInput()
    {
        Debug.Log(nameInput.text);
        gameManager.AddName(nameInput.text);
        playerName = nameInput.text;
        Debug.Log(playerName);
    }

    public void GoToGame () {
        Debug.Log("You Clicked Start Button");
        Debug.Log(playerName);
        if (playerName.Length < 3 || playerName.Length > 10)
        {
            errorMessageText.text = "Must be greater than 3  or less than 10 characters";
        }else{
            SceneManager.LoadScene("GameScene");
            errorMessage = "";
        }
    }

}