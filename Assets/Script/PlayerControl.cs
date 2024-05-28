using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public Animator aniPlayer;
    public Animator aniBoost;
    private Rigidbody2D rb;
    public GameObject PlayerBullet;
    public GameObject BulletPos;
    public AudioClip Fire;
    AudioSource audio1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio1 = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio1.clip = Fire;
            audio1.Play();
            GameObject bullet = (GameObject)Instantiate(PlayerBullet);
            bullet.transform.position = BulletPos.transform.position;
        }
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        if (movement == Vector2.right)
        {
            aniPlayer.SetBool("isRight", true);
            aniPlayer.SetBool("isLeft", false);
            aniPlayer.SetBool("isIdle", false);
            aniBoost.SetBool("isRight", true);
            aniBoost.SetBool("isLeft", false);
            aniBoost.SetBool("isIdle", false);
        }
        else if (movement == Vector2.left)
        {
            aniPlayer.SetBool("isLeft", true);
            aniPlayer.SetBool("isIdle", false);
            aniPlayer.SetBool("isRight", false);
            aniBoost.SetBool("isLeft", true);
            aniBoost.SetBool("isIdle", false);
            aniBoost.SetBool("isRight", false);
        }
        else
        {
            aniPlayer.SetBool("isIdle", true);
            aniPlayer.SetBool("isLeft", false);
            aniPlayer.SetBool("isRight", false);
            aniBoost.SetBool("isIdle", true);
            aniBoost.SetBool("isLeft", false);
            aniBoost.SetBool("isRight", false);
        }
    }
}