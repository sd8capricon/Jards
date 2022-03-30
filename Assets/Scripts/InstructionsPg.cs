using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsPg : MonoBehaviour
{
    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void creditsPage()
    {
        SceneManager.LoadScene("Credits");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainmenu();
        }
    }
}
