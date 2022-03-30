using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPP_RigidBody : MonoBehaviour
{
    public static bool canMove;
    public float yForce; //8
    public float zForce; //6
    public Rigidbody rb;
    public GameObject[] characters;

    private bool isGrounded = true;
    private int selectedCharacter;
    private int currentLane = 0;
    private float dragDistance;  //minimum distance for a swipe to be registered
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);
        Instantiate(characters[selectedCharacter], transform.position, Quaternion.identity, transform);
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Temp()
    {
        anim.SetBool("isJumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        //Check if grounded
        if(transform.position.y <= 0.55f)
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }

        // Forward Jump
        if (Input.GetButtonDown("Jump") && isGrounded && canMove)
        {
            anim.SetBool("isJumping", true);
            rb.AddForce(0, yForce, zForce, ForceMode.Impulse);
            Invoke("Temp", 0.5f);
            anim.SetBool("isFalling", true);
        }

        // Lane Movement
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && canMove && isGrounded == false)
        {
            if(currentLane != -1)
            {
                transform.position = new Vector3(-3, transform.position.y, transform.position.z);
                currentLane = -1;
            }
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && canMove && isGrounded == false)
        {
            if (currentLane != 1)
            {
                transform.position = new Vector3(3, transform.position.y, transform.position.z);
                currentLane = 1;
            }
        }

        if (Input.touchCount == 1 && canMove) // user is touching the screen with a single touch
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
                            //Debug.Log("Right Swipe");
                            if (currentLane != 1)
                            {
                                transform.position = new Vector3(3, transform.position.y, transform.position.z);
                                currentLane = 1;
                            }
                        }
                        else
                        {   //Left swipe
                            //Debug.Log("Left Swipe");
                            if (currentLane != -1)
                            {
                                transform.position = new Vector3(-3, transform.position.y, transform.position.z);
                                currentLane = -1;
                            }
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y && isGrounded)  //If the movement was up
                        {   //Up swipe
                            //Debug.Log("Up Swipe");
                            anim.SetBool("isJumping", true);
                            rb.AddForce(0, yForce, zForce, ForceMode.Impulse);
                            Invoke("Temp", 0.5f);
                            anim.SetBool("isFalling", true);
                        }
                        else
                        {   //Down swipe
                            //Debug.Log("Down Swipe");
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    //Debug.Log("Tap");
                }
            }
        }

        // Game Over
        if (rb.position.y < 0.3f)
        {
            FindObjectOfType<GameManager>().Endgame();
        }
    }
}