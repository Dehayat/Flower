using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 20f;
    public bool isMoving = true;
    public Animator anim;

    private Rigidbody2D rb;

    private bool wantToJump = false;
    private bool isJumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            wantToJump = true;
        }
    }

    private void FixedUpdate()
    {
        var velocity = rb.velocity;
        velocity.x = moveSpeed;
        rb.velocity = velocity;

        if (!isMoving)
        {
            velocity.x = 0;
            rb.velocity = velocity;
            return;
        }



        if (wantToJump)
        {
            isJumping = true;
            velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
            anim.SetBool("Jump", true);

            wantToJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Option>() != null)
        {
            var option = collision.GetComponent<Option>();
            PickupFlower(option);
        }
        if (collision.GetComponent<Line>() != null)
        {
            var line = collision.GetComponent<Line>();
            ShowLine(line);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        anim.SetBool("Jump", false);
    }

    private void ShowLine(Line line)
    {
        LineManager.instance.ChangeLine(line);
    }

    private void PickupFlower(Option option)
    {
        LineManager.instance.ChangeOption(option);
        Destroy(option.gameObject);
    }
}
