using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagArea : MonoBehaviour
{
    private bool player1IsInside = false;
    private bool player2IsInside = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // Assuming your player GameObjects are tagged with "Player1" and "Player2"
        if (other.CompareTag("PlayerA"))
        {
            player1IsInside = true;
            Debug.Log("player1 is inside");
            CheckWinCondition();
        }
        else if (other.CompareTag("PlayerB"))
        {
            player2IsInside = true;
            Debug.Log("player2 is inside");
            CheckWinCondition();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerA"))
        {
            player1IsInside = false;
            Debug.Log("player1 is out now");
        }
        else if (other.CompareTag("PlayerB"))
        {
            player2IsInside = false;
            Debug.Log("player2 is out now");
        }
    }
    private void CheckWinCondition()
    {
        // If both players are inside the circle, the game is won
        if (player1IsInside && player2IsInside)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        //what happens when the game is won
        Debug.Log("Game Won!");
       SceneManager.LoadScene("GameOverScene");
       Cursor.lockState = CursorLockMode.None;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
