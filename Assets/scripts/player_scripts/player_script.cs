using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{

    private const string ENEMY_TAG = "enemy";
    [SerializeField]
    private float motion_force;
    [SerializeField]
    private float jump_force;
    public float moveDir = 0;
    [SerializeField]
    private bool isGrounded = true;
    private Transform transform;
    private const string Walk_Animation = "walk";
    private const string Jump_Animation = "jump";
    private Animator animator;
    private Rigidbody2D myBody;
    private SpriteRenderer renderer;
    [SerializeField]
    private GameObject BulletReference;
    [SerializeField]
    private bool isBulletOnScreen;
    public static event Action onPlayerCollidesWithEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Awake()
    {
        bullet_script.onCollision += HandleDBullet;
    }
    void Start()
    {
        lives_manager_script.IfLives0 += endLife;
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        isBulletOnScreen = false;

    }

    // Update is called once per frame
    void Update()
    {
        walk_player();
        walk_animation();
        jump_player();
        ShootBullet();
        animator.SetBool(Jump_Animation, !isGrounded);
    }

    void walk_player()
    {

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            moveDir = -1f;
            transform.position += new Vector3(moveDir, 0, 0) * motion_force * Time.deltaTime;
            renderer.flipX = true;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            moveDir = 1f;
            transform.position += new Vector3(moveDir, 0, 0) * motion_force * Time.deltaTime;
            renderer.flipX = false;
        }
        else
        {
            moveDir = 0;
        }

    }
    void walk_animation()
    {
        if (moveDir != 0)
        {
            animator.SetBool(Walk_Animation, true);
        }
        else
        {
            animator.SetBool(Walk_Animation, false);
        }
    }
    void jump_player()
    {
        if (Keyboard.current.upArrowKey.isPressed && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jump_force), ForceMode2D.Impulse);
        }
    }




    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            isGrounded = true;
        }
        if (collision.collider.CompareTag(ENEMY_TAG))
        {
            Debug.Log("inside if");
            onPlayerCollidesWithEnemy?.Invoke();
            this.transform.position = new Vector2(-0.03f, -1.98f);
        }
    }
    void ShootBullet()
    {
        if (!isBulletOnScreen && Keyboard.current.spaceKey.IsPressed())
        {
            var bullet = Instantiate(BulletReference);



            isBulletOnScreen = true;
            if (renderer.flipX == true)
            {
                bullet.transform.position = new Vector2(this.GetComponent<CapsuleCollider2D>().bounds.center.x + this.GetComponent<CapsuleCollider2D>().bounds.extents.x + -0.5f, this.GetComponent<CapsuleCollider2D>().bounds.center.y);
                bullet.GetComponent<bullet_script>().speed = -10;
                bullet.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                bullet.transform.position = new Vector2(this.GetComponent<CapsuleCollider2D>().bounds.center.x + this.GetComponent<CapsuleCollider2D>().bounds.extents.x + 2f, this.GetComponent<CapsuleCollider2D>().bounds.center.y);
                bullet.GetComponent<bullet_script>().speed = 10;
                bullet.GetComponent<SpriteRenderer>().flipX = false;
            }

        }
    }
    void HandleDBullet()
    {
        isBulletOnScreen = false;
        //UnityEngine.Debug.Log("pika pika");
    }
    void endLife()
    {
        SceneManager.LoadScene("GameoverScene");
    }
    


}