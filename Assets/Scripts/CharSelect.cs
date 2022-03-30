using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharSelect : MonoBehaviour
{
    public int selectedCharacter = 0;
    public GameObject[] characterModels;
    public Character[] characters;
    public Button buyBtn;
    public Button selectBtn;

    private float dragDistance;  //minimum distance for a swipe to be registered
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Coin").GetComponent<TextMeshProUGUI>().text = "Coins: " + PlayerPrefs.GetInt("Coins", 0);
        foreach (GameObject characterModel in characterModels) characterModel.SetActive(false);
        foreach (Character character in characters)
        {
            if (character.price == 0) 
                character.isunlocked = true;
            else
                character.isunlocked = PlayerPrefs.GetInt(character.name, 0)==0 ? false : true;
        }
        characterModels[0].SetActive(true);
        UpdateBtns();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Coin").GetComponent<TextMeshProUGUI>().text = "Coins: " + PlayerPrefs.GetInt("Coins", 0);
        GameObject.Find("Name").GetComponent<TextMeshProUGUI>().text = characters[selectedCharacter].name;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Return();
        }

        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                            Prev();
                        }
                        else
                        {   //Left swipe
                            Debug.Log("Left Swipe");
                            Next();
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
    }

    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Next()
    {
        characterModels[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characterModels.Length;
        characterModels[selectedCharacter].SetActive(true);
        UpdateBtns();
    }

    public void Prev()
    {
        characterModels[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characterModels.Length;
        }
        characterModels[selectedCharacter].SetActive(true);
        UpdateBtns();
    }

    public void Select()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene("Menu");
    }

    public void Buy()
    {
        Character character = characters[selectedCharacter];
        PlayerPrefs.SetInt(character.name, 1);
        character.isunlocked = true;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - character.price);
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        //SceneManager.LoadScene("Menu");
        UpdateBtns();
    }

    public void UpdateBtns()
    {
        Character character = characters[selectedCharacter];
        if (character.isunlocked)
        {
            buyBtn.gameObject.SetActive(false);
            selectBtn.gameObject.SetActive(true);

        }
        else
        {
            selectBtn.gameObject.SetActive(false);
            buyBtn.gameObject.SetActive(true);
            buyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Buy - " + character.price;
            if (character.price <= PlayerPrefs.GetInt("Coins", 0)) 
                buyBtn.interactable = true;
            else 
                buyBtn.interactable = false;
        }
    }
}