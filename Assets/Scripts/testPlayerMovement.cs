﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class testPlayerMovement : MonoBehaviour
{
    public int loopCount = 0;

    public float speed;   //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;  //Store a reference to the Rigidbody2D component required to use 2D Physics.

    private float distanceToGround;

    public float fallMultiplier;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        distanceToGround = GetComponent<BoxCollider2D>().bounds.extents.y;
    }

    void Update()
    {


    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, 0);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.MovePosition(new Vector2((transform.position.x + moveHorizontal * Time.fixedDeltaTime), (transform.position.y + moveVertical * Time.fixedDeltaTime)));
        //Debug.Log(transform.position);
        if (transform.position.y <= -6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
            loopCount += 1;
            //Debug.Log(loopCount);
        }

        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier;
        }

    }
}

