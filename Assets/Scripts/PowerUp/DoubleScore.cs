using System;
using System.Collections;
using System.Collections.Generic;
using PowerUp;
using Unity.VisualScripting;
using UnityEngine;

public class DoubleScore : MonoBehaviour, IPowerUp
{
    private GameManager _gameManger;
    public PowerUpType powerUpType { get; }
    private void Start()
    {
        _gameManger = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _gameManger.DoubleScore();
            Destroy(this.gameObject);
        }
    }


    public void Spawn()
    {
        throw new NotImplementedException();
    }
}
