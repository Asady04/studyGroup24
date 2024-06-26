using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;

    void Awake()
    {
        speed = 7f;
        isReady = false;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;

        // Rotate the bullet to face the direction of movement
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
