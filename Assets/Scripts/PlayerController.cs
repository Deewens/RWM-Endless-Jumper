using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask _groundMask;
    
    private Rigidbody2D _rb;
    
    private bool _verticalInput; // Jump
    private bool _isJumping;
    
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GameOver();
        Jump();
    }

    private void Jump()
    {
        if (!_verticalInput || !IsGrounded()) return;

        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input.y > 0) _verticalInput = true;
        else _verticalInput = false;
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundMask);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Saw"))
        {
            _gameManager.ResetGame();
        }
    }

    private void GameOver()
    {
        if(transform.position.y < -4.5)
        {
            transform.position = new Vector3(-4.5f, -2.4f, 0);
            _gameManager.ResetGame();
        }
    }
}