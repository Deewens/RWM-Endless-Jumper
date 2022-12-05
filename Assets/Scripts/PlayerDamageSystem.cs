using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSystem : MonoBehaviour
{
    public int _playerDamage = 0;

    private int _duration;

    private void Start()
    {
        _duration = GameObject.FindGameObjectWithTag("ChasingEnemy").GetComponent<ChasingEnemy>().GetDuration();
    }

    public void SetDamage(int damage)
    {
        _playerDamage += damage;
        
        if (_playerDamage >= 2)
        {
            Destroy(gameObject);
        }
        else if (_playerDamage == 1)
        {
            StartCoroutine(Countdown(_duration * 2));
        }
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        ResetHealth();
    }

    void ResetHealth()
    {
        _playerDamage = 0;
    }
}
