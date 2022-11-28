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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
        }
    }
}
