using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        int num = Random.Range(0, 3);
        Transform spawnPoint = gameObject.transform.GetChild(0).transform;
        if (num == 0) Instantiate(coin, spawnPoint.position, Quaternion.Euler(90, 0, 0));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
