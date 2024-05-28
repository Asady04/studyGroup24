using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    float speed;
    Animator animator;
    bool isDestroyed = false;
    AudioSource audio1;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        animator = GetComponent<Animator>(); // Reference to the Animator component
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed)
        {
            Vector2 position = transform.position;
            position = new Vector2(position.x, position.y - speed * Time.deltaTime);
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            if (transform.position.y < min.y)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBullet" && !isDestroyed)
        {
            audio1 = GetComponent<AudioSource>();
            audio1.Play();
            isDestroyed = true;
            animator.SetTrigger("Destroy"); // Trigger the destruction animation
        }
    }

    // This function will be called by the animation event at the end of the destruction animation
    public void OnDestroyAnimationEnd()
    {
        Destroy(gameObject);
    }
}
