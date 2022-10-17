using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LevelController : MonoBehaviour
{
    [SerializeField] private float maxSpeed;


    private Vector2 _startPosition;

    public Vector2 StartPosition => _startPosition;

    private Rigidbody2D _rb;
    private bool _horizontalInput;
    private GameObject[] coin;

    void Start()
    {
        coin = GameObject.FindGameObjectsWithTag("Coin");
        _startPosition = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        if(transform.position.x <=  -74)
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            foreach (GameObject c in coin)
            {
                c.GetComponent<Coin>().ResetCoins();
            }

        }
    }
    private void FixedUpdate()
    {
        MoveHorizontally();
    }

    private void MoveHorizontally()
    {
        _rb.MovePosition((Vector2) transform.position + Vector2.left * (Time.deltaTime * maxSpeed));
    }
    
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input.x > 0) _horizontalInput = true;
        else _horizontalInput = false;
    }

}