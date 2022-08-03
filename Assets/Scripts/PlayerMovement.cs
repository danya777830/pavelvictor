using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isNormalized = true;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement != Vector2.zero)
        {
            animator.SetBool("canMove", true);
            Move(movement);
        }
        else{
            animator.SetBool("canMove", false);
        }
            
    }

    private void Move(Vector2 movement)
    { 
        Debug.Log(movement.x + " " + movement.y);
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
        if (isNormalized)
            rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
        else
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
       
    }
}
