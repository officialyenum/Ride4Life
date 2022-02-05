using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public float score = 0f;
    public string username = "Yenum";
    public int timeCounter = 60;
    public bool gameOver = false;
    public bool takingAway = false;

    public void Awake() {
        NoDestroyMethod();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            StartCoroutine(GoToHighScore());
        }
        if (score >= 100 || timeCounter <= 0f)
        {
            gameOver = true;
        }
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


    public void AddName(string value)
    {
        username = ""+value;
    }

    IEnumerator GoToHighScore () {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("HighScore");
    }

    

}
