using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repos : MonoBehaviour
{
    private GameObject player;
    private void OnCollisionEnter(Collision collision)
    {
        player.transform.position = new Vector3(player.transform.position.x, 0.5f, gameObject.transform.position.z);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
