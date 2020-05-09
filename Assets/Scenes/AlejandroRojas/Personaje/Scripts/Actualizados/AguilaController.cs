using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AguilaController : MonoBehaviour
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
    int contador = 1;
    void Update()
    {
        do
        {
            transform.position =
                new Vector3(transform.position.x + velocity * Time.deltaTime,
                transform.position.y,
                transform.position.z);
            sprite.flipX = false;
            contador++;
        } while (contador <= 20);
    }
}