using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static int coinNum;

    // Start is called before the first frame update
    void Start()
    {
        coinNum = int.Parse(GameManager.coinText.text);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
        if(GameObject.FindWithTag("Player").transform.position.z > transform.position.z + GameManager.coinDespawnDis)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        coinNum++;
        GameManager.coinText.text = coinNum.ToString("0");
        Destroy(gameObject);
    }
}
