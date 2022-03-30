using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public GameObject glassPrefab;
    public GameObject glassPrefabTemp;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        spawnGlass();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.spawnTile();
        Destroy(gameObject, 2);
    }

    void spawnGlass()
    {
        int spawnIndex = Random.Range(1, 3);
        Transform spawnPoint = transform.GetChild(spawnIndex).transform;
        if (spawnIndex == 1)
        {
            Transform spawnpointTemp = transform.GetChild(2).transform;
            Instantiate(glassPrefabTemp, spawnpointTemp.position, Quaternion.identity, transform);
        }
        else
        {
            Transform spawnpointTemp = transform.GetChild(1).transform;
            Instantiate(glassPrefabTemp, spawnpointTemp.position, Quaternion.identity, transform);
        }
        Instantiate(glassPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
