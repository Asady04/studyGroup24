using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    
    public void Play()
    {
        SceneManager.LoadScene("Map");
        Time.timeScale = 1;
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    // Update is called once per frame
   public void Exit()
   {
        Application.Quit();
        Debug.Log("Game Quit");
   }
}