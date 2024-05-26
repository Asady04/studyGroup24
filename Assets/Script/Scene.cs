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

    // Update is called once per frame
   public void Exit()
   {
        Application.Quit();
        // ScoreManager.instance.Reset();
        Debug.Log("Game Quit");
   }
}