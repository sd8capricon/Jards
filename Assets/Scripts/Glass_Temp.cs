using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glass_Temp : MonoBehaviour
{
    public static int scoreNum;
    public static float destroyDelay;
    public static float colorDelay;
    public static float speedIncrement;
    public static float maxSpeed;
    public GameObject self;
    public Material temp;
    public Material normal;

    private GameObject player;
    private bool colorChng = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreNum = int.Parse(GameManager.scoreText.text);
    }

    private void OnCollisionEnter(Collision collision)
    {
        scoreNum++;
        GameManager.scoreText.text = scoreNum.ToString("0");
        Debug.Log(scoreNum);
        if (scoreNum !=0 && scoreNum % 10 == 0 && Time.timeScale <= maxSpeed)
        {
            Time.timeScale += speedIncrement;
        }
        Destroy(gameObject, destroyDelay);
    }

    void Update()
    {
        if (transform.position.z - player.transform.position.z <= 20 && colorChng == false) // diff should be multiple of 10 +- 5 is for err in player movement
        {
            Invoke("RevealNature", 0f);
            Invoke("ConcealNature",colorDelay);
        }
    }

    void RevealNature()
    {
        self.GetComponent<MeshRenderer>().material = temp;
        colorChng = true;
    }

    void ConcealNature()
    {
        self.GetComponent<MeshRenderer>().material = normal;
    }
}
