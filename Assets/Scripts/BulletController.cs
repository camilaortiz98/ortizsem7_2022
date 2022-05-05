using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float velocity = 11;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
           
        }
    }
}
