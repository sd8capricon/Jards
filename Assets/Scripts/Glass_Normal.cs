using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass_Normal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Handheld.Vibrate();
        TPP_RigidBody.canMove = false;
        Destroy(gameObject);
        FindObjectOfType<GameManager>().Endgame();
    }

    void Start()
    {
        
    }
}
