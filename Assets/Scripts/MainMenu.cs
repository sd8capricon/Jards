using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public void showInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void charSelect()
    {
        SceneManager.LoadScene("CharSelect");
    }

    public void playGame()
    {
        Handheld.Vibrate();
        SceneManager.LoadScene("Main");
    }
    public void doExitGame() 
    {
        Application.Quit();
    }

    void Start()
    {
        GameObject.Find("Highscore Int").GetComponent<Text>().text = PlayerPrefs.GetInt("Highscore", 0).ToString("0");
        GameObject.Find("Coins").GetComponent<TextMeshProUGUI>().text = "Coins: " + PlayerPrefs.GetInt("Coins", 0);
        
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.tapCount == 2)
            {
                playGame();
            }
        }
    }
}
