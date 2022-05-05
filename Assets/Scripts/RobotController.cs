using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float velocity = 8;
    public float jumpForce = 70;
    public GameObject BulletPrefab;
    public GameObject BigBullet;

    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;
    // const 
    private const int IDLE = 0;
    private const int RUN = 1;
    private const int JUMP = 2;
    private const int RUNSHOOT = 3;
    private const int SHOOT = 4;
    private const int SLIDE = 5;
    private const int DEAD = 6;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(RUN);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(RUN);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(RUNSHOOT);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(RUNSHOOT);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            changeAnimation(JUMP);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            changeAnimation(SLIDE);
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            Disparar();
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            DispararBig();
        }
    }
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }

    private void Disparar()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        changeAnimation(SHOOT);
        var bulletGO = Instantiate(BulletPrefab, new Vector2(x,y), Quaternion.identity) as GameObject;

        if (sr.flipX)
        {
            var controller = bulletGO.GetComponent<BulletController>();
            controller.velocity *= -1; 
        }
    }

    private void DispararBig()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        changeAnimation(SHOOT);
        var BigbulletGO = Instantiate(BigBullet, new Vector2(x, y), Quaternion.identity) as GameObject;

        if (sr.flipX)
        {
            var controller = BigbulletGO.GetComponent<BulletController>();
            controller.velocity *= -1;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }*/
}
