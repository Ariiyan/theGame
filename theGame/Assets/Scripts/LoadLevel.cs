using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public AudioSource Button;
    private void Awake()
    {
        Manager.Player_Lives = 3;
    }
    public void LoadMyLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Button.Play();
    }
    public void Game_Quit()
    { 
    Application.Quit();
        Button.Play();

    }
}
