using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public AudioSource Audio;
    public enum GameState { MainMenu, Paused, Playing, GameOver};
    public GameState currentState;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI lifeText;
    public Image redKeyUI, /*blueKeyUI,*/ yellowKeyUI;
    public GameObject allGameUI, mainMenuPanel, pauseMenuPanel, gameOverPAnel;/*titleText;*/
    


    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "Main Menu")
        {
            CheckGameState(GameState.MainMenu);

        }
        else
        {
            CheckGameState(GameState.Playing);
        }
    }

    public void CheckGameState(GameState newGameState)
    {
        currentState = newGameState;
        switch (currentState)
        {
            case GameState.MainMenu:
                MainMenuSetup();
                break;
            case GameState.Paused:
                GamePaused();
                Manager.gamePaused = true;
                Time.timeScale = 0f;
                break;
            case GameState.Playing:
                GameActive();
                Manager.gamePaused = false;
                Time.timeScale = 1f;
                break;
            case GameState.GameOver:
                GameOver();
                Manager.gamePaused = true;
                Time.timeScale = 0f;
                break;
        }

    }

    public void MainMenuSetup()
    {
        allGameUI.SetActive(false);
        mainMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        gameOverPAnel.SetActive(false);
        Time.timeScale = 0f;

        //titleText.SetActive(true);

    }


    public void GameActive()
    {
        allGameUI.SetActive(true);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPAnel.SetActive(false);
        Time.timeScale = 1f;

        //  titleText.SetActive(false);
    }


    public void GamePaused()
    {
        allGameUI.SetActive(true);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        gameOverPAnel.SetActive(false);
        //titleText.SetActive(true);
    }



    public void GameOver()
    {

        Time.timeScale = 0f;    
        allGameUI.SetActive(true);
        mainMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPAnel.SetActive(true);
        PlatformController.Instance.gameObject.SetActive(false);
        //titleText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
        coinText.text= Manager.coins.ToString();
        lifeText.text= Manager.Player_Lives.ToString();
        if (Manager.coins >= 100)
        {
            Manager.coins -= 100;
            Manager.Add_Lives(1);
        
        }
        if (Manager.Player_Lives <= 0)
            GameOver();

        if (Manager.redKey)
        {
            redKeyUI.gameObject.SetActive(true);
        }if (Manager.yellowKey)
        {
            yellowKeyUI.gameObject.SetActive(true);
        }
    }
    
     void CheckInputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
                    {
                        CheckGameState(GameState.Paused);
                    } else if (currentState == GameState.Paused)
                    {
                        CheckGameState(GameState.Playing);
                    }

        }              
     }



   
    public void StartGame()
    {
        Time.timeScale = 1;

        Audio.Play();
        Manager.Player_Lives = 3;
        SceneManager.LoadScene("Level01");
        
        //CheckGameState(GameState.Playing);

    }
    public void Game_Quit()
    {
        Audio.Play();

        Application.Quit();
    }

public void PauseGame()
    {
        Audio.Play();

        CheckGameState(GameState.Paused);
    }



    public void ResumeGame()
    {
        Audio.Play();

        CheckGameState(GameState.Playing);
    }


    public void GoToMainMenu()
    {
        Audio.Play();
        SceneManager.LoadScene("Main Menu");
            CheckGameState(GameState.MainMenu);
    }

}
