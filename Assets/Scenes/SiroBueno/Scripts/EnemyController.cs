using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float maxSpeed = 10f;
    public float speed = 10f;
    private SpriteRenderer sprite;
    private Rigidbody2D rb2d;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        
        if (speed > 0f)
        {
            sprite.flipX = true;

        }
        else if (speed < 0f)
        {
            sprite.flipX = false;

        } 

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yOffset = 5.5f;
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.SendMessage("EnemyJump");
                Destroy(gameObject);
            } else
            {
                animator.SetTrigger("Die");
            }

            
        }
    }
}
