using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    int health;
    // public GameObject Healthh;
    // public GameObject HealthPos;
    public TMP_Text healthText;
    void Start()
    {
        health = 10;
        healthText.text = "Health: "+ health.ToString();
        // instance = this;
        // for(int i=0;i<health;i++){
        //     GameObject hati = (GameObject)Instantiate(Healthh);
        //     hati.transform.position = HealthPos.transform.position;
        // }
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
            healthText.text = "ceritanya game over";
        }
        // for(int i=0;i<health;i++){
        //     GameObject hati = (GameObject)Instantiate(Healthh);
        //     hati.transform.position = HealthPos.transform.position;
        // }
    }
}
