using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    public static StartGame startGame;
    public Button startButton;
    public InputField nameInput;
    public string playerName;
    public string errorMessage;
    public Text errorMessageText;

    private void Awake() 
    {
        errorMessageText = GameObject.Find("error").GetComponent<Text>();
        startButton.onClick.AddListener(GoToGame);
        nameInput.onValueChanged.AddListener(delegate {readPlayerInput(); });
        if (startGame == null)
        {
            startGame = this;
            DontDestroyOnLoad(this.gameObject);
        }else
        {
            Destroy(this.gameObject);
        }
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
        playerName = nameInput.text;
        Debug.Log(playerName);
    }

    public void GoToGame () {
        Debug.Log("You Clicked Start Button");
        Debug.Log(playerName);
        if (playerName.Length <= 5)
        {
            errorMessageText.text = "Must be greater than 5 characters";
        }else{
            SceneManager.LoadScene("GameScene");
            errorMessage = "";
        }
    }

}