using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDance : MonoBehaviour
{
    private int selectedCharacter;
    public GameObject[] characters;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject character in characters)
        {
            character.SetActive(false);
        }
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);
        characters[selectedCharacter].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
