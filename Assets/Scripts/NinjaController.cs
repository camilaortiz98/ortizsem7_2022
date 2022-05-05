using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public float velocity = 5;
    public int vidas = 3;

    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;
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
        rb.velocity = new Vector2(-velocity, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            sr.flipX = !sr.flipX;
            velocity *= -1;                
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            vidas = vidas - 1;
            if (vidas <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("BigBullet"))
        {
            vidas = vidas - 2;
            if (vidas <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LifeController.health -= 1;
        }
   
    }
}
