﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float min = -5;
    [SerializeField] float max = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
            
        }

    private void Move()
    {
        /*  var deltaX = Input.GetAxis("Horizontal");
           var newXPos = transform.position.x + deltaX;
           transform.position = new Vector2(newXPos, transform.position.y);
     */
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
         var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
         var newYPos = transform.position.y + deltaY;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, min, max);

         transform.position = new Vector2(newXPos, newYPos);
    }
}

