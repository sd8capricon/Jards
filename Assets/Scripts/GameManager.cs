using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float tempDelay; // Temp Glass Destroy Delay
    public float colorDelay; // Color chng delay on temp glass
    public float endDelay; // Delay for game end
    public float bgDelay;
    public float speedIncrement;
    public float maxSpeed;
    public float coinDespawnDist;
    public static float coinDespawnDis; // Diff in dist after which coin despawns
    public static Text scoreText;
    public static Text coinText;
    public Camera cam;

    private bool gameHasEnded = false;
    private int scoreNum;

    void Start()
    {
        cam = cam.GetComponent<Camera>();
        coinDespawnDis = coinDespawnDist * 10; // mul by 10 since dist between 2 tiles is 10
        Glass_Temp.maxSpeed = maxSpeed;
        Glass_Temp.speedIncrement = speedIncrement;
        Glass_Temp.destroyDelay = tempDelay;
        Glass_Temp.colorDelay = colorDelay;
        scoreText = GameObject.Find("Score Int").GetComponent<Text>();
        coinText = GameObject.Find("Coin Int").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        scoreNum = int.Parse(scoreText.text);

        float t = Mathf.PingPong(Time.time, bgDelay) / bgDelay;
        cam.backgroundColor = Color.Lerp(Color.cyan, Color.black, t);
    }

    public void Endgame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            PlayerPrefs.SetInt("RecScore", scoreNum);

            if(PlayerPrefs.GetInt("Highscore") < scoreNum)
            {
                PlayerPrefs.SetInt("Highscore", scoreNum);
            }

            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + Coin.coinNum);
            Invoke("EndScene", endDelay);
            Time.timeScale = 1f;
        }
    }

    void EndScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}