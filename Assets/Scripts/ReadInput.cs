using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadInput : MonoBehaviour
{
    static string inputtext;
    static string errorMessage;
    static public Text errorMessageText;
    // Start is called before the first frame update
    void Start()
    {
        errorMessageText = GameObject.Find("error").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    public void readPlayerInput(string s)
    {
        inputtext = s;
        Debug.Log(s);
        GameManager.playerName.text = s.ToString();
    }

    
}
