using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool alive = true;
    private int coinValue; // the added score value for a coin
    private Rigidbody2D rb;

    private GameManager scoreManager;

    private void Awake()
    {
        scoreManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
        rb = GetComponent<Rigidbody2D>();
        coinValue = 10;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            alive = false;
            scoreManager.setScore(coinValue);
            this.gameObject.SetActive(false);
        }
    }

    public void ResetCoins()
    {
        this.gameObject.SetActive(true);
    }
}