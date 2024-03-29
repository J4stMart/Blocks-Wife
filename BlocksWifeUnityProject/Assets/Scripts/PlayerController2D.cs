﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public bool flipped;

    public SpriteRenderer spriteRenderer;
    //private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            gravityVelocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (gravityVelocity.y > 0)
            {
                gravityVelocity.y *= 0.5f;
            }
        }

        bool flipSprite = (!flipped ? (move.x > 0f) : (move.x < 0f));
        if (flipSprite)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y);
            flipped = !flipped;
        }

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}