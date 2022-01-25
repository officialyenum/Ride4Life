using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    public Button startButton;
    private int count = 0;
    // Start is called before the first frame update
    void Start () {
        Button btn = startButton.GetComponent<Button> ();
        btn.onClick.AddListener(GoToGame);

    }

    // Update is called once per frame
    void Update () {

    }

    void GoToGame () {
        count++;
        Debug.Log ("You Clicked Start Button");
        Debug.Log ("You Clicked "+count+" Times");
    }
}