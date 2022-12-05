using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LevelController : MonoBehaviour
{
    private const float maxSpeed = 10;

    private float currentSpeed = 4;


    private Vector2 _startPosition;

    public Vector2 StartPosition => _startPosition;

    private Rigidbody2D _rb;
    private bool _horizontalInput;
    private GameObject[] coin;
    private float timePassed = 0;
    private float nextTimeToPass = 5;

    void Start()
    {
        coin = GameObject.FindGameObjectsWithTag("Coin");
        _startPosition = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        timePassed += Time.deltaTime;

        if (currentSpeed < maxSpeed)
        {
            if (timePassed > nextTimeToPass)
            {
                nextTimeToPass *= 1.5f;
                currentSpeed += 0.5f;
            }
        }
    }
    private void FixedUpdate()
    {
        MoveHorizontally();
    }

    private void MoveHorizontally()
    {
        _rb.MovePosition((Vector2) transform.position + Vector2.left * (Time.deltaTime * currentSpeed));
    }
    
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input.x > 0) _horizontalInput = true;
        else _horizontalInput = false;
    }

}