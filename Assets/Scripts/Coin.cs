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
        coinValue = 1;

    }
    
    private void Update()
    {
        Physics2D.queriesStartInColliders = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 10);

        if (hit.collider == null && GetComponent<Renderer>().isVisible)
        {
                Destroy(gameObject);
        }
        Debug.DrawRay(transform.position,-Vector2.up  * 10, Color.black);

        Physics2D.queriesStartInColliders = true;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            alive = false;
            scoreManager.setScore(coinValue);
            this.gameObject.SetActive(false);
        }
        else if (col.tag == "Coin")
        {
            Destroy(gameObject);
        }
    }

    public void ResetCoins()
    {
        this.gameObject.SetActive(true);
    }
}