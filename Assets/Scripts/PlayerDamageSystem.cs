using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSystem : MonoBehaviour
{
    public int _playerDamage = 0;

    public void SetDamage(int damage)
    {
        _playerDamage = damage;
        
        if (_playerDamage >= 2)
        {
            Destroy(gameObject);
        }
        else if (_playerDamage == 1)
        {
            // Move our chaser closer
        }
    }
}
