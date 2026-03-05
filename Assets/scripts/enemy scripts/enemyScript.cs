using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private Rigidbody2D MyBody;
    private const string BULLET_TAG = "bullet";
    public float speed;
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
    
}
