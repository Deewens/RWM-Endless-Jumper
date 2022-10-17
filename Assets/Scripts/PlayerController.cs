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

    private Vector2 _rayPosition;
    [SerializeField] private float rayDistance = 0.05f;

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody2D>();

        _rayPosition = transform.position;
    }

    void Update()
    {
        GameOver();
        Jump();

        _rayPosition = transform.position;
        _rayPosition.y -= 0.5f;
        _rayPosition.x -= 0.5f;
        Debug.DrawRay(_rayPosition, Vector2.down * rayDistance, Color.yellow);
    }

    private void Jump()
    {
        if (!_verticalInput || !IsGrounded()) return;

        _rb.velocity = Vector2.up * jumpForce;
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input.y > 0) _verticalInput = true;
        else _verticalInput = false;
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rayPosition, Vector2.down, rayDistance, _groundMask);
        
        return hit.collider != null;
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
