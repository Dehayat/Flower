using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FL
{
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            isJumping = false;
            anim.SetBool("Jump", false);
        }

        internal void Move()
        {
            isMoving = true;
            anim.speed = 1;
        }

        internal void Stop()
        {
            anim.speed = 0;
            isMoving = false;
        }
    }
}