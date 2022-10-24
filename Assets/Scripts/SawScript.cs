using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    private GameManager _gameManager;
    Transform axis;
    
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        axis = transform.GetChild(0);
    }

    void Update()
    {
        transform.RotateAround(axis.position, Vector3.forward, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _gameManager.ResetGame();
        }
    }
}
