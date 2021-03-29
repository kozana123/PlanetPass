using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public GameObject gameOverCanvas;
    public GameObject winningGameCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        if( gameHasEnded == false)
        {
            gameOverCanvas.SetActive(true);
            Invoke("GameOverScene", 1.5f);
        }
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene(2);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void WinningGame()
    {
        winningGameCanvas.SetActive(true);
        Invoke("BeginningScene", 1.5f);
    }

    public void BeginningScene()
    {
        SceneManager.LoadScene(0);
    }

}
