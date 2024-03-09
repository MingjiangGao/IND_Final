using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_SceneManager : MonoBehaviour
{
    // collecting the timer data from the GameManager
    public Text timerText;
    public float gameTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerText();
    }
     void UpdateTimerText()
    {
        if (GameManager.Instance != null && timerText != null){
            gameTime = GameManager.Instance.gameTime;
            timerText.text = "Time: " + Mathf.Ceil(gameTime).ToString();
        }
    }
}
