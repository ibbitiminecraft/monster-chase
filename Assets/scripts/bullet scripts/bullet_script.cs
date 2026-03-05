using UnityEngine;
using System;


public class bullet_script : MonoBehaviour
{
    private Rigidbody2D MyBody;
    private const string ENEMY_TAG = "enemy";
    private const string COLLECTOR_TAG = "collectors";
    public float speed;
    public static event Action onCollision;
    public static event Action onCollisionEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MyBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MyBody.linearVelocity = new Vector2(speed, MyBody.linearVelocity.y);
    }
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.collider.CompareTag(ENEMY_TAG))
    //     {
    //         Destroy(collision.collider.gameObject);
    //         onCollision?.Invoke();
    //         Destroy(gameObject);
    //     }
    //     if (collision.collider.CompareTag(COLLECTOR_TAG))
    //     {
    //         onCollision?.Invoke();
    //         Destroy(gameObject);
    //         Debug.Log("pika pika 2");
    //     }
    // }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(collision.gameObject);
            onCollision?.Invoke();
            onCollisionEnemy?.Invoke();
            Destroy(gameObject);
            
        }
        if (collision.CompareTag(COLLECTOR_TAG))
        {
            onCollision?.Invoke();
            Destroy(gameObject);
            Debug.Log("pika pika 2");
        }
    }
}
