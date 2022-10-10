using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed;
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
    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            alive = false;
            scoreManager.setScore(coinValue);
            Destroy(this.gameObject);
        }
    }

    private void Move()
    {
        Vector2 velocity = new Vector2(speed, 0) * Time.deltaTime;
        rb.velocity -= velocity;
    }



}
