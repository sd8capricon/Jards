using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (gamePaused) 
                Resume();
            else 
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        pauseMenuUI.SetActive(true);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }
}
