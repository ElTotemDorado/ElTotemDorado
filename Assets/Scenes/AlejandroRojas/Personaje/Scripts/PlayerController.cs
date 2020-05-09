using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    private Animator animator;
    private SpriteRenderer sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    float x;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Run", true);
                transform.position =
                new Vector3(transform.position.x + velocity * Time.deltaTime,
                transform.position.y,
                transform.position.z);
            }
            else
            {
                animator.SetBool("Run", false);
            }

            transform.position =
                new Vector3(transform.position.x + velocity * Time.deltaTime,
                transform.position.y,
                transform.position.z);
            animator.SetInteger("STATE", 1);
            sprite.flipX = false;
           
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Run", true);
                transform.position =
                new Vector3(transform.position.x - velocity * Time.deltaTime,
                transform.position.y,
                transform.position.z);
            }
            else
            {
                animator.SetBool("Run", false);
            }

            transform.position =
                new Vector3(transform.position.x - velocity * Time.deltaTime,
                transform.position.y,
                transform.position.z);
            animator.SetInteger("STATE", 1);
            sprite.flipX = true;
                        
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (sprite.flipX == true)
        //        sprite.flipX = false;
        //    animator.SetInteger("STATE", 2);
        //}
       if (!Input.anyKey)
       {
            animator.SetInteger("STATE", 0);
       }
    }
}