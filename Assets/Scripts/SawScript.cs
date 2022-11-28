using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    private GameManager _gameManager;

    private Collider2D m_col;
    
    Transform axis;
    
    void Start()
    {
        m_col = GetComponent<Collider2D>();
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
            PlayerDamageSystem damageSystem = col.GetComponent<PlayerDamageSystem>();
            if (damageSystem != null)
            {
                if (damageSystem._playerDamage == 0)
                {
                    damageSystem.SetDamage(1);
                    StartCoroutine(CountDownTimer());
                }
                
                else if (damageSystem._playerDamage == 1)
                {
                    damageSystem.SetDamage(2); // TODO: Increment the damage value rather than hardsetting it Also _playerdamage shouln't be public
                }
            }
        }
    }

    IEnumerator CountDownTimer()
    {
        m_col.enabled = false;
        yield return new WaitForSeconds(5f);
        m_col.enabled = true;
    }
    
}
