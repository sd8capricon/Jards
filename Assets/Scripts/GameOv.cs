using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOv : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>().text = "Score: " + PlayerPrefs.GetInt("RecScore", 0);
        GameObject.Find("Coin").GetComponent<TextMeshProUGUI>().text = "Coins: " + PlayerPrefs.GetInt("Coins", 0);
        GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt("Highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
