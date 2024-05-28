using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver = null;
    int health;
    public TMP_Text healthText;
    public AudioClip Dead;
    AudioSource audio1;

    void Start()
    {
        health = 5;
        healthText.text = "Health: "+ health.ToString();
        audio1 = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "EnemyBullet"){
            DestroyHealth();
        }
    }

    public void DestroyHealth(){
        health--;
        healthText.text = "Health: "+ health.ToString();
        if(health <= 0){
            audio1.clip = Dead;
            audio1.Play();
            ScoreManager.instance.GameOver();
            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
