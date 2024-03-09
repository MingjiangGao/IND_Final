using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   // Initiation
    public void ResetGameState()    
    {
    gameTime = 120f;
    UpdateTimerText();
    gameIsFrozen = false; // Ensure the game is not frozen
    StopAllCoroutines(); // Stop any existing countdown coroutine
    StartCoroutine(Countdown()); // Restart the countdown timer
    Debug.Log("Restart the game!");
    }

    // the counter
    public Text timerText;
    public float gameTime = 600f;
    private bool gameIsFrozen = false;

    IEnumerator Countdown()
    {
        while (gameTime > 0f)
        {
            yield return null;
        }
    }
     void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(gameTime).ToString();
        }
    }
    // Times-up - change scene
    void ShowRestartPage()
    {
          // Activate the restart page
        if (gameIsFrozen)
        {
            transition.LoadGameOver();
            Cursor.lockState = CursorLockMode.None;
        }
        // but now I use the scene change not the canva in 3D
    }
    
    // Transition settings 
    Transition transition;
    // donnot destroy
    public static GameManager Instance;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetGameState();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
         if (!gameIsFrozen)
        {
            gameTime -= Time.deltaTime;
            gameTime = Mathf.Max(gameTime, 0f);
            UpdateTimerText();

            if (gameTime <= 0f)
            {
                // Game timeout, freeze the game
                gameIsFrozen = true;
                // Show restart page (you can implement this part as needed)
                ShowRestartPage();
            }
        }
    }
}
