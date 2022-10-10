using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelController : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    
    private Rigidbody2D _rb;
    private bool _horizontalInput;
    
    private Vector2 _startPosition;

    public Vector2 StartPosition => _startPosition;

    void Start()
    {
        _startPosition = transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveHorizontally();
    }

    private void MoveHorizontally()
    {
        //if (!_horizontalInput) return;
        
        _rb.MovePosition((Vector2) transform.position + Vector2.left * (Time.deltaTime * maxSpeed));
    }
    
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input.x > 0) _horizontalInput = true;
        else _horizontalInput = false;
    }
}