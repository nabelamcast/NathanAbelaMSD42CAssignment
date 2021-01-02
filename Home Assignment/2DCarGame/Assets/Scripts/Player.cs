﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // SerializeField makes the variable editable from Unity
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.6f;

    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // Setting up a border around the camera
    private void SetUpMoveBoundaries()
    {
        // Retrieving camera from Unity
        Camera gameCamera = Camera.main;

        // Minimum and Maximum position of the camera
        // xMin = 0, xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        // yMin = 0, yMax = 1
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Moves the Car in the x-axis
    private void Move()
    {
        // deltaX is updated with the movement in the x-axis (left and right)
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        // newXPos = current x-pos of Player + difference in X by keyboard input
        var newXPos = transform.position.x + deltaX;

        // Clamps the newXPos between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        // The x-position will be updated according to the newXPos
        // Update the position of the player
        transform.position = new Vector2(newXPos, transform.position.y);
    }
}
