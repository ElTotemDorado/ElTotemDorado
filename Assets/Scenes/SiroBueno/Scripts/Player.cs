using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    [SerializeField] public LayerMask platformsLayerMask;
    private Animator animator;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
    private GameMaster gm;
    public GameObject gameover;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeIdle());
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    IEnumerator ChangeIdle()
    {
        yield return new WaitForSeconds(5);
        animator.SetInteger("State", 6);
        yield return new WaitForSeconds(0.5f);
        animator.SetInteger("State", 0);
        StartCoroutine(ChangeIdle());


    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {

            /*rb.MovePosition(new Vector3(transform.position.x + velocity * Time.deltaTime,
             rb.velocity.y + transform.position.y,
             transform.position.z));*/
            rb.velocity = new Vector2(velocity, rb.velocity.y);

            animator.SetInteger("State", 1);
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            /*  rb.MovePosition(new Vector3(transform.position.x - velocity * Time.deltaTime,
              rb.velocity.y + transform.position.y,
              transform.position.z));*/
            rb.velocity = new Vector2(-velocity, rb.velocity.y);

            animator.SetInteger("State", 1);
            sprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.E))
        {

            animator.SetInteger("State", 2);

        }
        if (Input.GetKey(KeyCode.E))
        {

            animator.SetInteger("State", 2);

        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 25f;
            rb.velocity = Vector2.up * jumpVelocity;
            animator.SetTrigger("Jump");

        }
        if (!Input.anyKey)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("State", 0);
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);

        return raycastHit2d.collider != null;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Luigi"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "pinchos")
        {
            animator.SetTrigger("Die");
            
        }
        if (other.gameObject.tag == "Arrow")
        {
            animator.SetTrigger("Die");
           
        }
        if (other.gameObject.tag == "Araña")
        {
            animator.SetTrigger("Die");
            
        }
        if (other.gameObject.tag == "SueloFalso")
        {
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "Totem")
        {
            Destroy(other.gameObject);

        }
    }
    public void EnemyJump()
    {
        float jumpVelocity = 25f;
        rb.velocity = Vector2.up * jumpVelocity;
        animator.SetTrigger("Jump");
    }


    public void GoToCheckponit()
    {

        transform.position = gm.lastCheckPointPos;
        animator.SetInteger("State", 0);
        animator.ResetTrigger("Die");
    }
   
}