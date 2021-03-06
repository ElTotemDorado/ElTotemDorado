﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    private Animator animator;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
            animator.SetTrigger("Check");
            
        }

    }
}