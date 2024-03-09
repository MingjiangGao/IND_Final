using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
        GameManager.Instance.ResetGameState();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("StartScene");
        GameManager.Instance.ResetGameState();
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadInstruction()
    {
        SceneManager.LoadScene("InstuctionScene");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            LoadMenu();
        }
    }
}
