using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public ParticleSystem blood;
    private ParticleSystem currentParticle;
    private GameManager _gameManager;
    private AudioSource _hurt;
    private Collider2D m_col;
    
    Transform axis;
    
    void Start()
    {
        m_col = GetComponent<Collider2D>();
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        axis = transform.GetChild(0);
        _hurt = GetComponent<AudioSource>();
    }

    void Update()
    {
        //transform.RotateAround(axis.position, Vector3.forward, 1);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            currentParticle = Instantiate(blood, col.gameObject.transform.position,Quaternion.identity,col.gameObject.transform);
            _hurt.Play();
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
