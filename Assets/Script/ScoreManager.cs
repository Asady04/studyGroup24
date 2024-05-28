using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoring;
    public TMP_Text highscoreText;
    int score=0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoring.text = "SCORE : " + score.ToString();
        highscoreText.text = "HIGHSCORE : " + highscore.ToString();
    }

    public void AddPoint(){
        score++;
        scoring.text = "Score :" + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
