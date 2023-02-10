﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f; //(acceleration)
    public float maxSpeed = 20.0f;
    public float deceleration = 35.0f;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude > 0)
        {
            velocity += direction * speed * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            velocity -= velocity.normalized * deceleration * Time.deltaTime;
            if (velocity.magnitude < 0.1f)
            {
                velocity = Vector3.zero;
            }
        }

        transform.position += velocity * Time.deltaTime;
    }
}