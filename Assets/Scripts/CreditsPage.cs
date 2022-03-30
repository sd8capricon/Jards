using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsPage : MonoBehaviour
{
   public void back()
   {
       SceneManager.LoadScene("Instructions");
   }
}
